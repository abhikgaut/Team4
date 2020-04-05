using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team4.Models;

namespace Team4.Controllers
{
    public class AdminController : Controller
    {
        static List<string> list = null;
        static List<string> list1 = null;
        // GET: Admin

        //Redirects to Add route view Where Admin can put values to fill route. 
        public ActionResult AddRoute()
        {
            ViewBag.loc = DbClass.senfFromTo();
            return View();

        }
        //takes the entered value to DbClass for inserting in database
        //and returns to new view with success message
        [HttpPost]
        public ActionResult AddRouteDB(addRoute A)
        {
            if (ModelState.IsValid)
            {
                ViewBag.loc = DbClass.senfFromTo();
                string from = Request.Form["From"];
                string to = Request.Form["To"];
                if (from == to)
                {
                    ViewBag.msg = "From location and Destination Cannot be same";
                    return View("AddRoute");
                }
                else
                {
                    int cost = int.Parse(Request.Form["Cost"]);
                    ViewBag.msg = DbClass.AddRoute(from, to, cost);
                    return View("AddRoute");
                }
            }
            ViewBag.loc = DbClass.senfFromTo();
            return View("AddRoute");
        }
        //Redirects to Add bus view Where Admin can put values to fill route.
        public ActionResult AddBus()
        {
            
            return View();
        }
        [HttpPost]
        //takes the entered value to DbClass for inserting in database
        //Also checks whether the entered bus capacity is correct with respect to bus type 
        //and returns to new view with success message
        public ActionResult AddBusDB(addBus Ab)
        {
            if (ModelState.IsValid)
            {
                string name = Request.Form["BusName"];
                string type = Request.Form["Type"];
                int capacity = int.Parse(Request.Form["Capacity"]);
                if (type == "A/C Semi Sleeper")
                {
                    if (capacity > 35)
                    {
                        ViewBag.msg = "capacity should be less than 35";
                        return View("AddBus");
                    }
                }
                else if (type == "A/C Sleeper")
                {
                    if (capacity > 25)
                    {
                        ViewBag.msg = "capacity should be less than 25";
                        return View("AddBus");
                    }
                }
                else if (type == "Non A/C seater")
                {
                    if (capacity > 45)
                    {
                        ViewBag.msg = "capacity should be less than 45";
                        return View("AddBus");
                    }
                }
                          
                ViewBag.msg = DbClass.AddBus(name, type, capacity);               
                return View("AddBus");
            }
            return View("AddBus");
        }
        //Redirects to Add Schedule view Where Admin can put values to fill route.
        //Also populates the existing dropdown of bus id and route id
        public ActionResult AddSchedule()
        {
            list = DbClass.GetRid();
            list1 = DbClass.GetBid();
            ViewBag.r = list;
            ViewBag.b = list1;
            return View();
        }
        //takes the entered value to DbClass for inserting in database
        //and returns to new view with success message
        public ActionResult AddScheduleDB(addSchedule As)
        {
            if (ModelState.IsValid)
            {
                As.Rid=As.Rid.Split('-')[0];
                As.Bid=As.Bid.Split('-')[0];
                list = DbClass.GetRid();
                list1 = DbClass.GetBid();
                ViewBag.r = list;
                ViewBag.b = list1;
                ViewBag.msg = DbClass.AddSchedule(As);
                return View("AddSchedule");
            }
            list = DbClass.GetRid();
            list1 = DbClass.GetBid();
            ViewBag.r = list;
            ViewBag.b = list1;
            return View("AddSchedule");
        }
    }
}