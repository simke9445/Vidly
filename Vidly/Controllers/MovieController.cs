using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult PageIndex(int? pageIndex, String sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (sortBy.IsNullOrWhiteSpace())
            {
                sortBy = "Name";
            }

            return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        }


        // ActionResult is the general class of ViewResult, and it's use is when
        // your program has different execution tabs, which return different results.
        // Best practice is to return the needed Result, because of Unit testing.

        // GET: Movie/Random
        public ViewResult Random()
        {
            var movie = new Movie() {Name = "Interstellar"};

            // that is equal to View(movie) because we assign the movie property to a 
            // viewModel
            // var viewResult = new ViewResult {ViewData = {Model = movie}};

            var customers = new List<Customer>()
            {
                new Customer() { Name = "Benedict"},
                new Customer() {Name = "Flavius"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };



            return View(viewModel);
        }

        public ViewResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        public ViewResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(x => x.Id == id);
            return View(movie);
        }

        private List<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie() {Name = "Wudaa", Id = 1},
                new Movie() {Name = "Zudaa", Id = 2}
            };
        } 
    }
}