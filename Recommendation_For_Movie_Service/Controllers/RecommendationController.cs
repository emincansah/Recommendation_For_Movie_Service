using Business.Interfaces;
using Hangfire;
using Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Recommendation_For_Movie_Service.Hangfire;
using RFM.Data.Entity.RequestModels;
using RFM.Data.Entity.ResponseModels;
using RFM.Entities.Conrete;
using System.Text;
using System.Text.Json;

namespace Recommendation_For_Movie_Service.Controllers
{
    [Produces("application/json")]

    public class RecommendationController : Controller
    {
        private readonly IDistributedCache _cache;
        private readonly IRecommendationService _recommendationService;
        private readonly IMovieService _movieService;
        private readonly IRabbitMqService _rabbitmqService;
        public RecommendationController(IDistributedCache cache,IRabbitMqService rabbitmqService,IMovieService movieService,IRecommendationService recommendationService)
        {
            this._cache = cache;
            this._movieService = movieService;
            this._recommendationService = recommendationService;
            this._rabbitmqService = rabbitmqService;
        }
        [Authorize]
        [HttpPost]
        [Route("api/Recommendation")]
        public async Task<IActionResult> PostRecommendation(RecommendationRequest request)
        {
            var cacheKey = Request.Headers[HeaderNames.Authorization].ToString();
            var getcachedata =  await _cache.GetAsync(cacheKey);
            if (getcachedata != null)
            {
                var cachedDataString = Encoding.UTF8.GetString(getcachedata);
                RecommendationRequest cacherequest = JsonSerializer.Deserialize<RecommendationRequest>(cachedDataString);
                if (request.Email == cacherequest.Email && request.MovieId == cacherequest.MovieId)
                {
                    return Conflict("already request");
                }
            }
            bool response = await _recommendationService.PostMovieRecommendation(request);
            if (response)
            {
                var cachedata = JsonSerializer.Serialize(request);
                DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5));
                await _cache.SetAsync(cacheKey, Encoding.UTF8.GetBytes(cachedata), options);
                _rabbitmqService.SendMail(request);
                return Ok();
            }
            else
                return BadRequest();





        }
    }
}
