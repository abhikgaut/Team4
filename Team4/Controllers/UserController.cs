using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team4.Models;

namespace Team4.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        static List<string> Clist = null;
        static List<string> SL = null;
        //redirects to login view after succesful registration
        //or act as starting view for project
        public ActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.msg = TempData["Message"].ToString();
                return View();
            }
            return View();
        }
        //takes login values and authenticate it against data stored in database
        //redirects to Admin or Customer based on login user type
        [HttpPost]
        public ActionResult getBack(loginValidation V)
        {
            if (ModelState.IsValid)
            {
                string user = Request.Form["Username"];
                string pass = Request.Form["Password"];
                Login_Table L = userBus.search(user,pass);
                if (L != null)
                {
                    Session["user"] = L.User_ID;
                    Session["type"] = L.UserType;
                    if (L.UserType == "Admin")
                        return View("page1");
                    else
                        return View("page2");
                }
                else
                {
                    ViewBag.msg = "Invalid Credentails";
                    return View("Index");
                }
            }
            return View("Index");
        }
        //gets triggered when logout potion is selected
        //clear all session variable to redirects to Index view
        public ActionResult logout()
        {
            if (Session["user"] != null)
            {
                Session.Abandon();
                Session.Clear();
            }
            return View("Index");
        }
        public ActionResult AddPage(string user,string pass)
        {
            return View();
        }
        //redirects to registration view
        public ActionResult registration()
        {
            Clist = userBus.SendCnames();
            ViewBag.CL = Clist;
            return View();
        }
        //redirects to Admin layout and available option
        public ActionResult page1()
        {
            return View();
        }
        //redirects to Customer layout and available option
        public ActionResult page2()
        {
            return View();
        }
        //populates the states dropdown based on country selected from dropdown
        public ActionResult getStates(string Country)
        {

            ViewBag.C = Country;
            SL = userBus.SendStates(Country);
            ViewBag.SList = new SelectList(SL);
            return PartialView("DisplayStates");
        }

        //get all the values entered by registering user and assign 
        //Customer type based on various option
        //send values to get updated in registration and login table
        [HttpPost]
        public ActionResult registration(regValidation C)
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

                //ViewBag.CL = Clist;

                ViewBag.msg = userBus.insertCustomer(C);
                regValidation C1 = userBus.insertLogin(C);
                if (C1 != null)
                {
                    TempData["Message"] = "Your Username is " + C.CustomeriD;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.msg = "Not Registered";
                    return View("registration");
                }

            }
            else
            {
                ViewBag.CL = Clist;
                return View("registration");
            }
        }
    }
}