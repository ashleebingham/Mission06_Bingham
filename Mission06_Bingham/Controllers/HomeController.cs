using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(new MovieAddition());
        }

        [HttpPost]
        public IActionResult Form(MovieAddition response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult MovieList()
        {

            // Fetch movies and handle potential NULL values
            var movies = _context.Movies
                .Select(movie => new MovieAddition
                {
                    MovieId = movie.MovieId,
                    Title = movie.Title ?? string.Empty, // Handle NULL title
                    CategoryId = movie.CategoryId, // Handle NULL category
                    Year = movie.Year, // Assuming Year is nullable, no need to handle explicitly
                    Director = movie.Director ?? string.Empty, // Handle NULL director
                    Rating = movie.Rating ?? string.Empty, // Handle NULL rating
                    Edited = movie.Edited, // Assuming Edited is nullable, no need to handle explicitly
                    LentTo = movie.LentTo ?? string.Empty, // Handle NULL lentTo
                    Notes = movie.Notes ?? string.Empty // Handle NULL notes
                })
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("Form", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(MovieAddition updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(MovieAddition addition)
        {
            _context.Movies.Remove(addition);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

    }
}
