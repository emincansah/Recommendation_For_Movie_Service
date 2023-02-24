using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Xunit;

namespace Test_RecommendationProject
{
    public class Tests
    {
       private  string _token =null;
       private RestClient _client = new RestClient();
       private RestRequest _request = new RestRequest();
       
        [Test]
        public async Task LoginTest()
        {
            _client = new RestClient("https://localhost:7292/api/Login");
            _client.Timeout = -1;
            _request = new RestRequest(Method.POST);
            _request.AddHeader("Content-Type", "application/json");
            var body = @"{""username"": ""test"",""password"": ""test123""}";
            _request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = _client.Execute(_request);
            var res = JsonConvert.DeserializeObject<respone>(response.Content.ToString());
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.token);
            _token=res.token;

        }
        
        [Test]
        public async Task GetMovieListTest()
        {
            _client = new RestClient("https://localhost:7292/api/GetMovie?PageNumber=1");
            _client.Timeout = -1;
            _request = new RestRequest(Method.GET);
            _request.AddHeader("Authorization", $"Bearer {_token}");
            var response = _client.Execute(_request);
            var res = JsonConvert.DeserializeObject<MovieList>(response.Content.ToString());
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.movies);
        }

        [Test]
        public async Task GetMovieTest()
        {
            _client = new RestClient("https://localhost:7292/api/GetMovieDetail?MovieId=11278");
            _client.Timeout = -1;
            _request = new RestRequest(Method.GET);
            _request.AddHeader("Authorization", $"Bearer {_token}");
            var response = _client.Execute(_request);
            var res = JsonConvert.DeserializeObject<MovieList>(response.Content.ToString());
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.movies);
        }
        [Test]
        public async Task PostMovieVoteTest()
        {
            _client = new RestClient("https://localhost:7292/api/PostVote?MovieId=1&Vote=1&Note=1"); 
            _client.Timeout = -1;
            _request = new RestRequest(Method.POST);
            _request.AddHeader("Authorization", $"Bearer {_token}");
            var response = _client.Execute(_request);
            Assert.Equals(200, (int)response.StatusCode);
        }
        [Test]
        public async Task PostRecommendationTest()
        {
            _client = new RestClient("https://localhost:7292/api/PostVote?MovieId=1&Vote=1&Note=1");
            _client.Timeout = -1;
            _request = new RestRequest(Method.POST);
            _request.AddHeader("Authorization", $"Bearer {_token}");
            var response = _client.Execute(_request);
            Assert.Equals(200, (int)response.StatusCode);

        }

        public class Movie
        {
            public object original_language { get; set; }
            public string title { get; set; }
            public string overview { get; set; }
            public int vote_average { get; set; }
            public int vote_count { get; set; }
            public int id { get; set; }
        }

        public class MovieList
        {
            public List<Movie> movies { get; set; }
            public int total_results { get; set; }
            public int total_pages { get; set; }
        }

        public class respone {
            public string token { get; set; }
            public string expiration { get; set; }
        }
    }
}