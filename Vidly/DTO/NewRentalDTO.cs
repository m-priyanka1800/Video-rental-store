using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTO
{
    public class NewRentalDTO
    {
        public int Id { get; set; }

        [Required]
        public int customerId { get; set; }

        [Required]
        public int[] movieIds { get; set; }

        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }

    }
}