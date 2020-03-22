using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models.CustomValidations;

namespace Vidly.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Display (Name = "Date of Birth")]
        [MinAgeIs18]
        public DateTime? DateofBirth { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display (Name= "Membership Type")]
        public byte MembershipTypeID { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
    }
}