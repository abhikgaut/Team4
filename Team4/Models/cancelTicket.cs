using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team4.Models
{
    public class cancelTicket
    {
        int cid;
        string bid;

        [Required(ErrorMessage = "Customer Id not entered")]
        public int Cid { get => cid; set => cid = value; }

        [Required(ErrorMessage = "Booking Id not entered")]
        public string Bid { get => bid; set => bid = value; }
    }
}