using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team4.Models
{
    public class addBus
    {
        
        string busName;
        string type;
        int capacity;

        
        [Required(ErrorMessage = "Name not entered")]
        public string BusName { get => busName; set => busName = value; }
        [Required(ErrorMessage = "Bus type not entered")]
        public string Type { get => type; set => type = value; }
        [Required(ErrorMessage = "Capacity not entered")]
        public int Capacity { get => capacity; set => capacity = value; }
    }
}