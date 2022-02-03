using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private MovieSubmissionContext _movieContext { get; set; }

        public HomeController(MovieSubmissionContext name)
        {
           _movieContext = name;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Form(FormSubmission response)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(response); //this proposes changes, does not save them
                _movieContext.SaveChanges(); // must include this to save

                return View("Submission", response);
            }
            else
            {
                return View(response);
            }
            
        }
        public IActionResult MovieList()
        {
            var submissions = _movieContext.Responses
                .Include(x => x.Category)
                .ToList();

            return View(submissions);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            var response = _movieContext.Responses.Single(x => x.MovieID == movieid);

            return View("Form", response);
        }

        [HttpPost]
        public IActionResult Edit(FormSubmission response)
        {
            _movieContext.Update(response);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete (int movieid)
        {
            var movie = _movieContext.Responses.Single(x => x.MovieID == movieid);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(FormSubmission response)
        {
            _movieContext.Responses.Remove(response);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

    }
}
