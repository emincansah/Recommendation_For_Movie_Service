using Business.Interfaces;
using Hangfire;
using Helpers;
using Newtonsoft.Json;
using RestSharp;
using RFM.Data.Entity.ResponseModels;
using RFM.Entities.Conrete;
using RFM.Helper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static RFM.Helper.Enums.Enums;

namespace Recommendation_For_Movie_Service.Hangfire
{

    public class Hangfirehelper
    {
        private  readonly string apikey = "a249086abbb6a0bcd83d4b096ff8acb9";
        private  readonly string apiurl = "https://api.themoviedb.org/3/"; 
        private  readonly IRecommendationService _recommendationService;    
        private readonly IMovieService _movieService;

        public Hangfirehelper(IMovieService movieService, IRecommendationService recommendationService)
        {
            this._movieService = movieService;
            this._recommendationService = recommendationService;
        }

        public async Task ProcessEnqueueMovieJob()
        {
           
            var client = new RestClient();

            int nowyear = DateTime.Now.Year;
            for (int i = 1888; i <= nowyear; i++)
            {
                var request = new RestRequest($"{apiurl}discover/movie?primary_release_year={i}&api_key={apikey}", Method.Get);
                RestResponse response = client.Execute(request);
                var responses = JsonConvert.DeserializeObject<TmdbListResponseEntity>(response.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                foreach (var movie in responses.results)
                {
                    Movies movies = new Movies();
                    movies.title = movie.title;
                    movies.overview=movie.overview;
                    movies.original_language = movies.original_language;
                    await _movieService.PostMovie(movies);
                }

            }

        }


        public async Task ProcessRecurringMailJob(RecommendationRequest request)
        {
            var appSettingsJson = AppSettingsJson.GetAppSettings();
            EmailConfiguration emailConfig = new EmailConfiguration();

            emailConfig.From = appSettingsJson["EmailConfiguration:From"];
            emailConfig.SmtpServer = appSettingsJson["EmailConfiguration:SmtpServer"];
            emailConfig.Port = int.Parse(appSettingsJson["EmailConfiguration:Port"]);
            emailConfig.UserName = appSettingsJson["EmailConfiguration:Username"];
            emailConfig.Password = appSettingsJson["EmailConfiguration:Password"];
            
            SmtpClient client = new SmtpClient(emailConfig.SmtpServer, 587);
            NetworkCredential AccountInfo = new NetworkCredential(emailConfig.UserName, emailConfig.Password);
            client.UseDefaultCredentials = false;
            client.Credentials = AccountInfo;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

        
            // yıl bazlı film listesi alma
            var emailaction =await _recommendationService.GetMovieRecommendation(request);
            if (emailaction !=null)
            {

                try
                {
                    MailMessage msg = new MailMessage();
                    msg.Subject = "Movie Recommendation";
                    msg.From = new MailAddress(emailConfig.From, "Movie Recommendation");
                    msg.To.Add(new MailAddress(emailaction.email));
                    msg.Body = "Movies Id = <br>" + emailaction.moiveId;
                    msg.IsBodyHtml = true;
                    msg.Priority = MailPriority.High;
                    client.Send(msg);
                    emailaction.status= EmailStatus.Draft.GetIntValue();
                    await _recommendationService.PostMovieRecommendationUpdate(emailaction);
                }
                catch (Exception)
                {

                    throw;
                }

            }
       



            }

        

    }
}
