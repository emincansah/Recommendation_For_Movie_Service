using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFM.Data.Entity.RequestModels;
using RFM.Data.Entity.ResponseModels;


namespace Recommendation_For_Movie_Service.Controllers
{
    [Produces("application/json")]
   
   

    public class MovieController : Controller
    {
       
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService )
        {  
            this._movieService = movieService;
        }

        [Authorize]
        [HttpGet]
        [Route("api/GetMovie")]

        public async Task<IActionResult> GetMovieList(MovieListRequest request)
        {
            var movieslist = await _movieService.GetMoviesList(request);
            return Ok(movieslist);
        }

        [Authorize]
        [HttpGet]
        [Route("api/GetMovieDetail")]

        public async Task<IActionResult> GetMovieDetail(MovieDetailRequest request)
        {
            var movie = await _movieService.GetMovies(request.MovieId);
            return Ok(movie);
        }


       
    }
}
