using Business.Interfaces;
using Hangfire;
using Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recommendation_For_Movie_Service.Hangfire;
using RFM.Data.Entity.RequestModels;
using RFM.Data.Entity.ResponseModels;
using RFM.Entities.Conrete;

namespace Recommendation_For_Movie_Service.Controllers
{
    [Produces("application/json")]

    public class RecommendationController : Controller
    {
      
        private readonly IRecommendationService _recommendationService;
        private readonly IMovieService _movieService;
        public RecommendationController(IMovieService movieService,IRecommendationService recommendationService)
        {
            this._movieService = movieService;
            this._recommendationService = recommendationService;
        }
        [Authorize]
        [HttpPost]
        [Route("api/Recommendation")]
        public async Task<IActionResult> PostRecommendation(RecommendationRequest request)
        {
            bool response =await _recommendationService.PostMovieRecommendation(request);
            if (response)
            {
                Hangfirehelper _cc = new Hangfirehelper(_movieService, _recommendationService);
                
                BackgroundJob.Enqueue(() => _cc.ProcessRecurringMailJob( request));
                return Ok();
            }
            
            else
                return BadRequest();

        }
    }
}
