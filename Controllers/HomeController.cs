using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;

        private MovieSubmissionContext _movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieSubmissionContext name)
        {
            _logger = logger;
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

    }
}
