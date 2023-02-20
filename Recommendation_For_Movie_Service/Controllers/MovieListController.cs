using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Recommendation_For_Movie_Service.Controllers
{
    [Produces("application/json")]
    [Route("api/MovieList")]
    //[ApiController]
   
    public class MovieListController : Controller
    {
        [Authorize]
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
