using ASP.NET_Core_MVC_Practical.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.NET_Core_MVC_Practical.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly MovieContext _movieContext;

        public DirectorsController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //DirectorModel Dirmodel = new DirectorModel();
            //Dirmodel.CountryList = new List<SelectListItem>();
            //var data = _movieContext.Directors.ToList();

            //Dirmodel.CountryList.Add(new SelectListItem
            //{
            //    Text = "Select Country",
            //    Value = ""
            //});
            //foreach (var item in data)
            //{
            //    Dirmodel.CountryList.Add(new SelectListItem
            //    {
            //        Text = item.Country,
            //        Value = item.DirectorId.ToString()
            //    });
            //    Dirmo
            //}

            //List<Director> directors = new List<Director>();
            //var allData = _movieContext.Directors.ToList();
            //directors = allData;

            //DirectorViewModel dvm = new DirectorViewModel()
            //{
            //    DiractorsList = directors,
            //    Counties = 
            //};

            var dirList = _movieContext.Directors.ToList();

            return View(dirList);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {

            var searchDirectors = _movieContext.Directors.Where(s => s.DirectorName.Contains(search) || s.Country.Contains(search)).ToList();
            if (searchDirectors != null && search != null)
            {
                return View(searchDirectors);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
