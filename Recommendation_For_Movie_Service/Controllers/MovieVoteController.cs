using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFM.Data.Entity.RequestModels;

namespace Recommendation_For_Movie_Service.Controllers
{
    [Produces("application/json")]
    public class MovieVoteController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IMovieVoteService _movievoteService;
        public MovieVoteController(IMovieVoteService movievoteService, IMovieService movieService)
        {
                 this._movieService = movieService;
                 this._movievoteService = movievoteService;
        }

        [Authorize]
        [Route("api/PostVote")]
        [HttpPost]
        public async Task<IActionResult> PostVote(MovieVoteRequest request)
        {
            var votepost = await _movievoteService.PostVote(request);
            var updateresult = await _movieService.Update(request);
            if (votepost && updateresult)
                return Ok();
            else     
                return BadRequest();
            
        }
    }
}
