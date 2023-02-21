using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFM.Data.Entity.RequestModels;
using RFM.Data.Entity.ResponseModels;
using RFM.Data.Repository;

namespace Recommendation_For_Movie_Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Movie")]
    //[ApiController]
   
    public class MovieController : Controller
    {
        [Authorize]
        [HttpGet]
        public MovieListResponse GetMovieList(MovieListRequest request)
        {
             return MovieRepository.GetMovieList(request);
        }

        [Authorize]
        [HttpGet]
        public MovieDetailResponse GetMovieDetail(MovieDetailRequest request)
        {
            return MovieRepository.GetMovieDetail(request); 
        }
        [Authorize]
        [HttpPost]
        public MovieVoteResponse PostVote(MovieVoteRequest request)
        {
            return MovieRepository.PostMovieVote(request);
        }
    }
}
