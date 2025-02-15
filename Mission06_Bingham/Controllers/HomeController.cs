using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Bingham.Models;

namespace Mission06.Controllers
{
    public class HomeController : Controller
    {
        private MovieInformationContext _context;
        public HomeController(MovieInformationContext movie)
        {
            _context = movie;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(MovieAddition response)
        {
            _context.MovieDetails.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
