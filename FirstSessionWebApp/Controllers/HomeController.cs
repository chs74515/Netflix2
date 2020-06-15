using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirstSessionWebApp.Models;
using FirstSessionWebApp.Data;
using Microsoft.EntityFrameworkCore;
using FirstSessionWebApp.ViewModels;

namespace FirstSessionWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Category).ToList();
            return View(movies);
        }

        public IActionResult VideoClubs()
        {
            var videos = _context.VideoClubs;
            return View(videos);
        }

        public IActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Category).Where(x => x.Id == id).FirstOrDefault();
            return View(movie);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult AddNewMovies()
        {
            // HttpGet and HttpPost - EVERYTHING! 
            MovieCategoryViewModel mcvm = new MovieCategoryViewModel();
            var cats = _context.Categories.ToList();
            mcvm.Categories = cats;

            return View(mcvm);
        }

        [HttpPost]
        public IActionResult AddNewMovies(Movie movie) 
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            //var movies = _context.Movies.ToList();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) 
        {
            // logic delete
            var movie = _context.Movies.Where(m => m.Id == id).FirstOrDefault();
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
