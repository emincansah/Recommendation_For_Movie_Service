using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFM.Data.Entity.RequestModels;
using RFM.Data.Entity.ResponseModels;
using RFM.Data.Repository;

namespace Recommendation_For_Movie_Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Recommendation")]
    public class RecommendationController : Controller
    {
      
        [Authorize]
        [HttpPost]
        public RecommendationResponse PostRecommendation(RecommendationRequest request)
        {
            return RecommendationRepository.PostRecommendation(request);
        }
    }
}
