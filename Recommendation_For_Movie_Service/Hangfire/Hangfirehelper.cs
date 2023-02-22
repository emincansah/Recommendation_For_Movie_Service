using Hangfire;
using Newtonsoft.Json;
using RestSharp;
using RFM.Data.Entity;
using RFM.Data.Entity.EntityModel;
using RFM.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace Recommendation_For_Movie_Service.Hangfire
{
  
    public class Hangfirehelper
    {
        private static readonly string apikey = "a249086abbb6a0bcd83d4b096ff8acb9";
        private static readonly string apiurl = "https://api.themoviedb.org/3/";
        private static Hangfirehelper hangfirehelper;

        private readonly EmailConfiguration _emailConfig;
        public  Hangfirehelper(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
            hangfirehelper = this;
        }
       
        public static void ProcessRecurringMovieJob()
        {
            // yıl bazlı film listesi alma
            var options = new RestClientOptions("")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);

            int nowyear = DateTime.Now.Year;
            for (int i = 1888; i <= nowyear; i++)
            {
                var request = new RestRequest($"{apiurl}discover/movie?primary_release_year={i}&api_key={apikey}", Method.Get);
                RestResponse response = client.Execute(request);
                var responses = JsonConvert.DeserializeObject<TmdbListResponseEntity>(response.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            }

        }


        public static void ProcessRecurringMailJob()
        {
            string filter = "status == 1";
            // yıl bazlı film listesi alma
            var emailactionlist = EmailRepository.GetActionList(filter);
            EmailConfiguration emailConfig = hangfirehelper._emailConfig;
            SmtpClient client = new SmtpClient(emailConfig.SmtpServer, 587);
            NetworkCredential AccountInfo = new NetworkCredential(emailConfig.UserName, emailConfig.Password);
            client.UseDefaultCredentials = false;
            client.Credentials = AccountInfo;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
           
            foreach (var emailAction in emailactionlist)
            {
                try
                {
                    MailMessage msg = new MailMessage();
                    msg.Subject = "Movie Recommendation";
                    msg.From = new MailAddress(emailConfig.From, "Movie Recommendation");
                    msg.To.Add(new MailAddress(emailAction.email));
                    msg.Body = "Movies Id = <br>" + emailAction.moiveId;
                    msg.IsBodyHtml = true;
                    msg.Priority = MailPriority.High;
                    client.Send(msg);
                     EmailRepository.UpdateAction(emailAction.Id);
                }
                catch (Exception)
                {

                    throw;
                }
               
                
            }
           
           



        }

    }
}
