using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team4.Models
{
    public class bookTickets
    {
        int cid;
        string from;
        string to;
        //DateTime starttime;
        int not;

        [Required(ErrorMessage = "Customer id not entered")]
        public int Cid { get => cid; set => cid = value; }
        [Required(ErrorMessage = "From location not entered")]
        public string From { get => from; set => from = value; }
        [Required(ErrorMessage = "Destination not entered")]
        public string To { get => to; set => to = value; }
        [Required(ErrorMessage = "Date of journey not entered")]
        [DataType(DataType.Date)]
        [customtime]
        public DateTime Starttime { get ; set ; }
        [Required(ErrorMessage = "Number of tickets not entered")]
        [Range(1,4, ErrorMessage = "Maximum no of tickets are 4")]
        public int Not { get => not; set => not = value; }
    }
}