using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int GenreID { get; set; }
        public Genre Genre { get; set; }

        [Required]
        [Display (Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
                public DateTime DateAdded { get; set; }

        [Required]
        [Range(1,20)]
        [Display (Name ="Number in stock")]
        public int Num_in_Stock { get; set; }
        
        public int Num_Available { get; set; }
    }
}