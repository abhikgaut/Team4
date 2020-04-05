using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team4.Models
{
    public class addRoute
    {
        string from;
        string to;
        int cost;
        [Required(ErrorMessage = "From location not entered")]
        public string From { get => from; set => from = value; }
        [Required(ErrorMessage = "Destination not entered")]
        public string To { get => to; set => to = value; }
        [Required(ErrorMessage = "Cost not entered")]
        public int Cost { get => cost; set => cost = value; }
    }
}