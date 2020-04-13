using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team4.Models;

namespace Team4.Controllers
{
    public class CustomerController : Controller
    {
        static List<string> Clist = null;
        // GET: Customer

        //takes to book ticket view with already populated Customer id
        public ActionResult BookTickets()
        {
            ViewBag.cid = Session["user"];
            return View();
        }
        //takes entered value to DbClass which extracts details with respect to entered value
        //and display on BookTickets view
        [HttpPost]
        public ActionResult CheckBus(bookTickets B)
        {
            if (ModelState.IsValid)
            {
                Session["not"] = B.Not;
                ViewBag.cid = Session["user"];
                List<SP_Test_Result> S= DbClass.FindTickets(B);
                if (S.Count() == 0)
                {
                    ViewBag.bd = null;
                    ViewBag.nb = "Sorry, No booking found for given date";
                }
                else
                    ViewBag.bd = S;
                return View("BookTickets");
            }
            return View("BookTickets");
        }
        //takes SID and other session variable to DbClass to confirm booking by user
        [HttpPost]
        public ActionResult Bookbus()
        {
            int seats = Convert.ToInt32(Session["not"]);
            int cid = Convert.ToInt32(Session["user"]);
            string[] sid  = Request.Form["sid"].ToString().Split('=');
            string s = sid[1].Split('}')[0].ToString().Trim();
            ViewBag.msg = DbClass.BookTicket(s,seats,cid);
            ViewBag.cid = Session["user"];
            return View("BookTickets");
        }
        //takes to cancel ticket view with already existing Customer id and Ticket id 
        public ActionResult CancelTickets()
        {
            int cid = Convert.ToInt32(Session["user"]);
            ViewBag.cid = Convert.ToInt32(Session["user"]);
            ViewBag.Bookid = DbClass.GetBookid(cid);
            return View();
        }
        //takes entered values to DbClass and return confir cancellation message
        public ActionResult Cancelbus(cancelTicket C)
        {
            if (ModelState.IsValid)
            {
                string bookid = C.Bid;
                ViewBag.msg = DbClass.CancelTicket(bookid);
                int cid1 = Convert.ToInt32(Session["user"]);
                ViewBag.cid = Convert.ToInt32(Session["user"]);
                ViewBag.Bookid = DbClass.GetBookid(cid1);
                return View("CancelTickets");
            }
            int cid = Convert.ToInt32(Session["user"]);
            ViewBag.cid = Convert.ToInt32(Session["user"]);
            ViewBag.Bookid = DbClass.GetBookid(cid);
            return View("CancelTickets");
        }
        //the view that displays cofirmation of cancelled ticket
        public ActionResult CancelConfirm()
        {
            return View();
        }
        //display information of current logged in user in editable text boxes
        public ActionResult UpdateProfile()
        {
            Clist = userBus.SendCnames();
            ViewBag.CL = Clist;
            int cid = Convert.ToInt32(Session["user"]);
            Customer_Table C = DbClass.GetCustomerInfo(cid);
            updateDetails R = new updateDetails();
            R.Name = C.Name;
            R.Address = C.Address;
            R.City = C.City;
            R.State = C.State;
            R.Country = C.Country;
            R.Pincode = C.Pincode.ToString();
            R.Email = C.Email;
            R.Contact = C.Contactno;
            R.Ctype = C.CustomerType;
            R.Dob = C.DateOfBirth;
            return View(R);
        }
        //takes the edited text values and calculates new user type 
        //sends to DbClass to update value in database
        public ActionResult GetUpdatedValue(updateDetails C)
        {
            if (ModelState.IsValid)
            {


                string CustomerType = C.Ctype;

                int Weightage = 0;
                if (CustomerType == "Government Officer")
                {
                    C.Ctype = "High";
                    Weightage = 10;
                }
                else if (CustomerType == "Government Employee")
                {
                    C.Ctype = "Normal";
                    Weightage = 5;
                }
                else if (CustomerType == "Private Employee")
                {
                    C.Ctype = "Normal";
                    Weightage = 5;
                }
                else if (CustomerType == "Student")
                {
                    C.Ctype = "Normal";
                    Weightage = 5;
                }
                else if (CustomerType == "Others")
                {
                    C.Ctype = "Normal";
                    Weightage = 5;
                }

                int cid = Convert.ToInt32(Session["user"]);
                Clist = userBus.SendCnames();
                ViewBag.CL = Clist;
                ViewBag.msg = DbClass.updateCustomer(C,cid);                    
                    return View("UpdateProfile");
                

            }
            Clist = userBus.SendCnames();
            ViewBag.CL = Clist;
                return View("UpdateProfile");
            
        }
        //takes to view which displays booking history of current user
        public ActionResult History()
        {
            int cid = Convert.ToInt32(Session["user"]);
            List<history_Result> l = DbClass.FindHistory(cid);
            if (l.Count() == 0)
            {
                ViewBag.L = null;
                ViewBag.msg = "No bookings were made till date";
            }
            else
                ViewBag.L = l;
            return View();
        }
    }
}