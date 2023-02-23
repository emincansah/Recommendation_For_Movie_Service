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


            var appSettingsJson = AppSettingsJson.GetAppSettings();  
            EmailConfiguration _emailConfig =new EmailConfiguration();

            _emailConfig.From = appSettingsJson["EmailConfiguration:From"];
            _emailConfig.SmtpServer = appSettingsJson["EmailConfiguration:SmtpServer"];
            _emailConfig.Port =int.Parse( appSettingsJson["EmailConfiguration:Port"]);
            _emailConfig.UserName = appSettingsJson["EmailConfiguration:Username"];
            _emailConfig.Password = appSettingsJson["EmailConfiguration:Password"];
         
            RecurringJob.AddOrUpdate(() => _cc.ProcessRecurringMailJob(_emailConfig), Cron.Hourly);

            return  null;
        }
    }
}
