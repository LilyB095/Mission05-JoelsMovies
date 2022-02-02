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
        private MovieContext blahContext { get; set; }

        public HomeController(MovieContext someName)
        {
            blahContext = someName;
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
            blahContext.Add(ar);
            blahContext.SaveChanges();

            return View("Confirmation", ar);
        }

    }
}
