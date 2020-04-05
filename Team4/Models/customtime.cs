using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team4.Models
{
    public class customtime : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime D = Convert.ToDateTime(value);
            DateTime TD = DateTime.Now;
            int age = (int)(D.Subtract(TD).TotalDays);
            if (D < TD)
                return new ValidationResult("Date cannot be lesser than today age");
            else if (age > 2)
                return new ValidationResult("Next two days can be booked");
            else
                return ValidationResult.Success;
        }
    }
}