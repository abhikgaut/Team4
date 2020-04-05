using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team4.Models
{
    public class customDOJ : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime D = Convert.ToDateTime(value);
            DateTime TD = DateTime.Now;
            int age = (int)(TD.Subtract(D).TotalDays / 365);
            if (D > TD)
                return new ValidationResult("Date cannot be greater than today age");
            else if (age < 18 || age > 80)
                return new ValidationResult("Age must be between 18-80");
            else
                return ValidationResult.Success;
        }
    }
}