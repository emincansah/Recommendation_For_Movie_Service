using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFM.Data.Entity.RequestModels;
using RFM.Data.Entity.ResponseModels;


namespace Recommendation_For_Movie_Service.Controllers
{
    [Produces("application/json")]

    public class RecommendationController : Controller
    {
      
        private readonly IRecommendationService _recommendationService;
        public RecommendationController(IRecommendationService recommendationService)
        {
            this._recommendationService = recommendationService;
        }
        [Authorize]
        [HttpPost]
        [Route("api/Recommendation")]
        public async Task<IActionResult> PostRecommendation(RecommendationRequest request)
        {
            bool response =await _recommendationService.PostMovieRecommendation(request);
            if (response)
                return Ok();
            else
                return BadRequest();

        }
    }
}
