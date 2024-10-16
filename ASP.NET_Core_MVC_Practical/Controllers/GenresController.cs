using ASP.NET_Core_MVC_Practical.Models;

using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_MVC_Practical.Controllers
{
    public class GenresController : Controller
    {
        private readonly MovieContext _movieContext;

        public GenresController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }


        public IActionResult Index()
        {
            var genreList = _movieContext.Genres.ToList();
            return View(genreList);
        }
    }
}
