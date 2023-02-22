using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFM.Data.Entity.RequestModels;
using RFM.Data.Entity.ResponseModels;


namespace Recommendation_For_Movie_Service.Controllers
{
    [Produces("application/json")]

    public class RecommendationController : Controller
    {
        [Authorize]
        [HttpPost]
        [Route("api/Recommendation")]
        public IActionResult PostRecommendation(RecommendationRequest request)
        {
            //return RecommendationRepository.PostRecommendation(request);
            return Ok();
        }
    }
}
