using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.CustomValidations
{
    public class MinAgeIs18:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeID == 0 ||customer.MembershipTypeID == 1)
                return ValidationResult.Success;
            if (customer.DateofBirth == null)
                return new ValidationResult("The Birthday field is required");

            var age = DateTime.Now.Year - customer.DateofBirth.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("You need to be over 18 to apply for a membership");

        }
    }
}