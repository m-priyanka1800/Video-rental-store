using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        public ApplicationDbContext _contextMovie;

        public MovieController()
        {
            _contextMovie = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _contextMovie.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _contextMovie.Movies.Include(c => c.Genre);
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _contextMovie.Movies.Include(m => m.Genre).SingleOrDefault(m => m.ID == id);
            if (movie != null)
            {
                return View(movie);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult New()
        {
            MovieViewModel movieViewModel  = new MovieViewModel{
                movie_Genre = _contextMovie.Genres.ToList()};
            return View("MovieForm",movieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                MovieViewModel movieViewModel = new MovieViewModel(movie)
                {
                    movie_Genre = _contextMovie.Genres.ToList()
                };
                return View("MovieForm", movieViewModel);
            }
            
            else
            {
                if (movie.ID == 0)
                {
                    movie.DateAdded = DateTime.Now;
                    _contextMovie.Movies.Add(movie);
                }
                else
                {
                    var movieInDB = _contextMovie.Movies.Single(m => m.ID == movie.ID);
                    movieInDB.GenreID = movie.GenreID;
                    movieInDB.Name = movie.Name;
                    movieInDB.Num_in_Stock = movie.Num_in_Stock;
                    movieInDB.ReleaseDate = movie.ReleaseDate;
                }
                _contextMovie.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }

        }

        public ActionResult Edit(int id)
        {
            MovieViewModel movieViewModel = new MovieViewModel(_contextMovie.Movies.Single(m => m.ID == id))
            {
                movie_Genre = _contextMovie.Genres.ToList()
            };

            return View("MovieForm", movieViewModel);
        }
    }
}