using Hangfire;
using Newtonsoft.Json;
using RestSharp;
using RFM.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Recommendation_For_Movie_Service.Hangfire
{

    public class Hangfirehelper
    {
        private static readonly string apikey = "a249086abbb6a0bcd83d4b096ff8acb9";
        private static readonly string apiurl = "https://api.themoviedb.org/3/";

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

    }
}
