using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class MoviesController : ApiController
    {
        public ApplicationDbContext _context { get; set; }

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET all movies
        [HttpGet]
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies.Include(m => m.Genre).Where(m => m.Num_Available > 0);

            if (!string.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            var movies = moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDTO>);

            return Ok(movies);
        }

        //GET specific movie
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            IEnumerable<MovieDTO> movie = _context.Movies
                .Where(m => m.ID == id)
                .Include(m => m.Genre)
                .Select(Mapper.Map<Movie, MovieDTO>);
            return Ok(movie);
        }

        //POST create new customer
        [HttpPost]
        [Authorize(Roles = RoleNames.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }
            return Created(new Uri(Request.RequestUri + "/" + movieDTO.ID), movieDTO.ID);
        }

        //PUT create new customer
        [HttpPut]
        [Authorize(Roles = RoleNames.CanManageMovies)]
        public IHttpActionResult EditMovie(MovieDTO movieDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.Select(m => m.ID == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDTO,movieInDb);
            _context.SaveChanges();
            return Ok("Movie updated successfully.");
        }

        //DELETE movie
        [HttpDelete]
        [Authorize(Roles = RoleNames.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieIDb = _context.Movies.SingleOrDefault(m => m.ID == id);
            if (movieIDb == null)
                return NotFound();
            _context.Movies.Remove(movieIDb);
            _context.SaveChanges();
            return Ok("Movie deleted successfully.");
        }
    }
}