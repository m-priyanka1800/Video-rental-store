using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.Models.CustomValidations;

namespace Vidly.DTO
{
    public class CustomerDTO
    {
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        //[MinAgeIs18]
        public DateTime? DateofBirth { get; set; }

        public MembershipTypeDTO MembershipType { get; set; }

        public byte MembershipTypeID { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

    }
}