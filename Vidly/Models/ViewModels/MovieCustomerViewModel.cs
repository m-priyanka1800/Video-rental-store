using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models.ViewModels
{
    public class MovieCustomerViewModel
    {
        public Movie movie { get; set; }
        public List<Customer> customers { get; set; }
    }
}