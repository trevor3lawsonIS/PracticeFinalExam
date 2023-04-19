using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PracticeFinalExam.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeFinalExam.Controllers
{
    public class HomeController : Controller
    {
        private IMovieRepository repo { get; set; }
        public HomeController(IMovieRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovie()
        {
            ViewBag.Categories = repo.GetCategories();
            return View("NewMovie", new Movie());
        }

        [HttpPost]
        public IActionResult NewMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.AddMovie(movie);
                return View("Confirmation", movie);
            }
            else
            {
                return View();
            }
        }

        public IActionResult MyMovies()
        {
            var movies = repo.GetMovies();
            return View(movies);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = repo.GetCategories();
            var movie = repo.GetMovieByID(id);
            return View("NewMovie", movie);
        }
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            repo.UpdateMovie(movie);
            return RedirectToAction("MyMovies");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = repo.GetMovieByID(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            repo.RemoveMovie(id);
            return RedirectToAction("MyMovies");
        }


        public IActionResult Podcasts()
        {
            return View();
        }
    }
}
