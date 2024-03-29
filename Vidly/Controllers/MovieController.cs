﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
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
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ViewResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(x => x.Id == id);
            return View(movie);
        }

        public ActionResult MovieForm(Movie movie, string source)
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList(),
                Movie = movie,
                SourceActionName = source
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Name = movie.Name;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList(),
                SourceActionName = "Edit"
            };

            return View("MovieForm", viewModel);
        }
    }
}