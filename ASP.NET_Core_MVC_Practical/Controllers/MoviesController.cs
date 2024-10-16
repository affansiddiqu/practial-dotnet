using ASP.NET_Core_MVC_Practical.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace ASP.NET_Core_MVC_Practical.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _movieContext;
        public MoviesController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public IActionResult Index(int? pageno)
        {
            if(pageno.HasValue)
            {
                int pageNo = (int) pageno;
                if (pageNo < 1)
                {
                    pageNo = 1;

                }
                var movieList = _movieContext.Movies.Include(g => g.Genre).Include(d => d.Director).Skip((pageNo - 1) * 3).Take(3).ToList();
                return View(movieList);
            }
            else
            {
                var movieList = _movieContext.Movies.Include(g => g.Genre).Include(d => d.Director).Take(3).ToList();
                return View(movieList);

            }
          
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            var seaechMovieList = _movieContext.Movies.Include(g => g.Genre).Include(d => d.Director).Where(s => s.Title.Contains(search) || s.Genre.GenreName.Contains(search) || s.Director.DirectorName.Contains(search) || s.Director.Country.Contains(search)).ToList();
            if (seaechMovieList != null && search != null)
            {
                return View(seaechMovieList);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
