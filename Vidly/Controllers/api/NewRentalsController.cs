using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class NewRentalsController : ApiController
    {
        public ApplicationDbContext _context = new ApplicationDbContext();
        //Create a new rental
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDTO newRentalDTO)
        {
            var customer = _context.Customers.Single(c => c.ID == newRentalDTO.customerId);
            var movies = _context.Movies.Where(m => newRentalDTO.movieIds.Contains(m.ID));

            foreach (var movie in movies)
            {
                if (movie.Num_Available == 0)
                    return BadRequest("Movie is not available.");
                movie.Num_Available--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
