using Business.Interfaces;
using Hangfire;
using Helpers;
using Microsoft.AspNetCore.Mvc;
using Recommendation_For_Movie_Service.Hangfire;
using RFM.Entities.Conrete;

namespace Recommendation_For_Movie_Service.Controllers
{
    [Produces("application/json")]

    public class HomeController : Controller
    {
        private readonly IRecommendationService _recommendationService;
        private readonly IMovieService _movieService;

        public HomeController(IMovieService movieService, IRecommendationService recommendationService)
        {
            this._movieService = movieService;
            this._recommendationService = recommendationService;
        }
        [HttpGet]
        [Route("Home/Index")]
        public async Task<IActionResult> Index()
        {
            Hangfirehelper _cc = new Hangfirehelper(_movieService,_recommendationService);           
            BackgroundJob.Enqueue(() => _cc.ProcessEnqueueMovieJob());
            return  new RedirectResult("~/swagger");

            
        }
    }
}
