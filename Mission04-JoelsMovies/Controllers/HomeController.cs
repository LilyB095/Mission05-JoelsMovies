using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse ar)
        {
            daContext.Add(ar);
            daContext.SaveChanges();

            return View("Confirmation", ar);
        }

        public IActionResult MovieList()
        {
            var applications = daContext.Responses
                .OrderBy(x=> x.Category)
                .OrderBy(x => x.Title)
                .OrderBy(x => x.Title)
                .ToList();

            return View(applications);
        }
    }
}
