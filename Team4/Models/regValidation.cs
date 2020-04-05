using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team4.Models
{
    public class regValidation
    {
        string name;
        string address;
        string city;
        string state;
        string country;
        string pincode;
        string email;
        string gender;
        string contact;
        DateTime dob;
        string ctype;
        string password;
        string cpassword;
        string customeriD;

        [Required(ErrorMessage = "Name not entered")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Enter only alphabets and space")]
        public string Name { get => name; set => name = value; }
        [Required(ErrorMessage = "Address not entered")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "No special characters")]
        public string Address { get => address; set => address = value; }
        [Required(ErrorMessage = "City not entered")]
        public string City { get => city; set => city = value; }        
        [Required(ErrorMessage = "Country not entered")]
        public string Country { get => country; set => country = value; }
        [Required(ErrorMessage = "State not entered")]
        public string State { get => state; set => state = value; }
        [Required(ErrorMessage = "Pincode not entered")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "Required size is 6 digit")]
        public string Pincode { get => pincode; set => pincode = value; }
        [Required(ErrorMessage = "Email not entered")]
        [EmailAddress(ErrorMessage = "Email not valid")]
        public string Email { get => email; set => email = value; }
        [Required(ErrorMessage = "Gender not entered")]
        public string Gender { get => gender; set => gender = value; }
        [Required(ErrorMessage = "Contact not entered")]
        [MinLength(10, ErrorMessage = "Phone no should be 10")]
        [MaxLength(10, ErrorMessage = "Phone no should be 10")]
        public string Contact { get => contact; set => contact = value; }
        [Required(ErrorMessage = "Date of birth not entered")]
        [customDOJ]
        public DateTime Dob { get => dob; set => dob = value; }
        [Required(ErrorMessage = "User type not entered")]
        public string Ctype { get => ctype; set => ctype = value; }
        [Required(ErrorMessage = "Password not entered")]
        public string Password { get => password; set => password = value; }
        [Required(ErrorMessage = "Password not entered")]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        public string Cpassword { get => cpassword; set => cpassword = value; }
        public string CustomeriD { get => customeriD; set => customeriD = value; }

    }
}