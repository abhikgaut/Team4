using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team4.Models
{
    public class addSchedule
    {
        string rid;
        string bid;
        
        int capacity;
        [Required(ErrorMessage = "Route id not entered")]
        public string Rid { get => rid; set => rid = value; }
        [Required(ErrorMessage = "Bus id not entered")]
        public string Bid { get => bid; set => bid = value; }
        [Required(ErrorMessage = "Start time not entered")]
        [DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime StartTime { get ; set ; }
        [Required(ErrorMessage = "Date of journey not entered")]
        [DataType(DataType.Date)]
        [customdate]
        public DateTime Doj { get ; set ; }
        [Required(ErrorMessage = "Capacity not entered")]
        public int Capacity { get => capacity; set => capacity = value; }
        //public List<BusDetails_Table> BusDetails_Tables { get; set; }
        //public List<Route_Table> Route_Tables { get; set; }
    }
}