using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.ViewModels
{
    public class MovieViewModel
    {
        public MovieViewModel()
        {
            ID = 0;
        }

        public MovieViewModel(Movie movie)
        {
            ID = movie.ID;
            Name = movie.Name;
            GenreID = movie.GenreID;
            ReleaseDate = movie.ReleaseDate;
            Num_in_Stock = movie.Num_in_Stock;
        }
        public IEnumerable<Genre> movie_Genre { get; set; }

        public int? ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int? GenreID { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in stock")]
        public int? Num_in_Stock { get; set; }

        public string Title
        {
            get
            { return (ID != 0) ? "Edit Movie": "New Movie"; }
        }


    }
}