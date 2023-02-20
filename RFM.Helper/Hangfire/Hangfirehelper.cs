using Hangfire;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RFM.Helper.Hangfire
{
    public class Hangfirehelper
    {
            public static void ProcessRecurringJob()
            {
            // yıl bazlı film listesi alma
            var options = new RestClientOptions("")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("https://api.themoviedb.org/3/discover/movie?primary_release_year=1888&api_key=a249086abbb6a0bcd83d4b096ff8acb9", Method.Get);
            RestResponse response =  client.Execute(request);
            var responses = JsonConvert.DeserializeObject<TmdbListResponse>(response.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }); 

        }
        
    }
}
