using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission04_JoelsMovies.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission04_JoelsMovies.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext daContext { get; set; }

        public HomeController(MovieContext someName)
        {
            daContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SeeMyPodcasts()
        {
            return View("MyPodcasts");
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.myCategories = daContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                daContext.Add(ar);
                daContext.SaveChanges();

                return View("Confirmation", ar);
            }
            else // if invalid :D
            {
                ViewBag.myCategories = daContext.Categories.ToList();
                return View(ar);
            }
        }

        public IActionResult MovieList()
        {
            var applications = daContext.Responses
                .Include(x => x.Category)
                .OrderBy(x=> x.Category.CategoryName)
                .ThenBy(x=> x.Title)
                .ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.myCategories = daContext.Categories.ToList();
            var application = daContext.Responses.Single(x => x.MovieId == movieid);
            
            return View("MovieForm", application);
        }
        [HttpPost]
        public IActionResult Edit(ApplicationResponse fairy)
        {
            daContext.Update(fairy);
            daContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var yadda = daContext.Responses.Single(x => x.MovieId == movieid);

            return View(yadda);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            daContext.Responses.Remove(ar);
            daContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
