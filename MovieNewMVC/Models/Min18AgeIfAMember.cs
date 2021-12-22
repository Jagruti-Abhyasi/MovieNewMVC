using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieNewMVC.Models
{
    public class Min18AgeIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            //if(customer.MembershipId == 0 || customer.MembershipId == 1)
            // replace magic no with static readonly field, so code will be more maintainable
            // we can use ENUM as alternative option,but then we need casting 
            if (customer.MembershipId == Membership.Unknown || customer.MembershipId == Membership.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required..");
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18) ? ValidationResult.Success :
                new ValidationResult("Customer should be atleast 18 years old");
        }
    }
}