using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstSessionWebApp.Data;
using FirstSessionWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstSessionWebApp.Controllers
{
    public class VideoClubsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<VideoClubsController> _logger;

        public VideoClubsController(ILogger<VideoClubsController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var videos = _context.VideoClubs.ToList();
            return View(videos);
        }


        [HttpGet]
        public IActionResult Create()
        {
            // HttpGet and HttpPost - EVERYTHING! 
            return View();
        }

        [HttpPost]
        public IActionResult Create(VideoClubs video)
        {
            _context.VideoClubs.Add(video);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: VideoClubsController/Details/5
        public ActionResult Details(int id)
        {
            var vc = _context.VideoClubs.Where(c => c.ID == id).FirstOrDefault();

            return View(vc);
        }


        // GET: VideoClubsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VideoClubsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VideoClubsController/Delete/5
        public ActionResult Delete(int id)
        {
            var vc = _context.VideoClubs.Where(c => c.ID == id).FirstOrDefault();
            _context.VideoClubs.Remove(vc);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: VideoClubsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
