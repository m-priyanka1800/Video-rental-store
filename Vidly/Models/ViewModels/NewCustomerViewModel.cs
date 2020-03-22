using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<MembershipType> cust_membershipTypes { get; set; }
        public Customer customer { get; set; }
    }
}