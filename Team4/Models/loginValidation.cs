using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team4.Models
{
    public class loginValidation
    {
        string username;
        string password;

        [Required(ErrorMessage = "User name not entered")]
        public string Username { get => username; set => username = value; }

        [Required(ErrorMessage = "Password not entered")]
        public string Password { get => password; set => password = value; }
    }
}