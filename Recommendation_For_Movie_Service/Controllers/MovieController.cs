using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFM.Data.Entity.ResponseModels;
using RFM.Data.Repository;

namespace Recommendation_For_Movie_Service.Controllers
{
    [Produces("application/json")]
    [Route("api/MovieList")]
    //[ApiController]
   
    public class MovieController : Controller
    {
        [Authorize]
        [HttpGet]
        [Route("Index")] 
        public MovieListResponse GetMovieList(MovieListRequest request)
        {
            MovieListResponse response = new MovieListResponse();
             response = MovieRepository.GetMovieList(request);
            return response;
        }
        [Authorize]
        [HttpGet]
        [Route("Index")]
        public MovieDetailResponse GetMovieDetail(MovieDetailRequest request)
        {
            MovieDetailResponse response = new MovieDetailResponse();
            response = MovieRepository.GetMovieDetail(request);
            return response;
        }
    }
}
