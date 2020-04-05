using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Team4.Models
{
    public class DbClass
    {
        static Team4Entities d = new Team4Entities();
        //takes the required values and add route related information to database
        public static string AddRoute(string From,string To,int Cost)
        {
            try
            {
                var b = from L in d.Route_Table
                        where L.From.ToUpper() == From.ToUpper() && L.To.ToUpper() == To.ToUpper()
                        select L;
                if (b.Count() > 0)
                    return "route already exists";
                int rid = (from r in d.Route_Table
                           select r).Count() + 1;
                Route_Table Rt = new Route_Table();
                Rt.Route_ID = "R" + string.Format("{0:000}", rid);
                Rt.From = From;
                Rt.To = To;
                Rt.Cost = Cost;
                d.Route_Table.Add(Rt);
                d.SaveChanges();
                return "Route details from " + Rt.From + " to " + Rt.To + " added . Route ID is" + Rt.Route_ID;
            }
            catch (DbUpdateException E)
            {
                SqlException ex = E.GetBaseException() as SqlException;
                if (ex.Message.Contains("PK_Route_Table"))
                {
                    return "Route id already exists";
                }
            }
            return null;
        }
        //takes the required values and add bus related information to database
        public static string AddBus(string name, string type, int capacity)
        {
            try
            {
                var b = from L in d.BusDetails_Table
                        where L.Bus_Name.ToUpper() == name.ToUpper() && L.Type.ToUpper() == type.ToUpper()
                        select L;
                if (b.Count() > 0)
                    return "route already exists";
                int rid = (from r in d.BusDetails_Table
                           select r).Count() + 1;
                BusDetails_Table Bt = new BusDetails_Table();

                Bt.Bus_ID = "B" + string.Format("{0:000}", rid);
                Bt.Bus_Name = name;
                Bt.Type = type;
                Bt.Capacity = capacity;
                d.BusDetails_Table.Add(Bt);
                d.SaveChanges();
                return "Bus details created for " + Bt.Bus_Name + " of type " + Bt.Type + " with capacity " + Bt.Capacity + ". Bus ID is " + Bt.Bus_ID;
            }
            catch (DbUpdateException E)
            {
                SqlException ex = E.GetBaseException() as SqlException;
                if (ex.Message.Contains("PK_BusDetails_Table"))
                {
                    return "Bus id already exists";
                }
            }
            return null;
        }
        //extract all rows from Route_Table and send it as list
        public static List<string> GetRid()
        {
            try
            {
                var EN = from L in d.Route_Table
                         select L.Route_ID + "-" + L.From + "-" + L.To;
                int count = EN.Count();
                return EN.ToList();
            }
            catch (DbUpdateException E)
            {
                SqlException ex = E.GetBaseException() as SqlException;
            }
            return null;
        }
        //extract all rows from BusDetails_Table and send it as list
        public static List<string> GetBid()
        {
            try
            {
                var EN = from L in d.BusDetails_Table
                         select L.Bus_ID + "-" + L.Bus_Name + "-" + L.Type + "-" + L.Capacity;
                return EN.ToList();
            }
            catch (DbUpdateException E)
            {
                SqlException ex = E.GetBaseException() as SqlException;
            }
            return null;
        }
        //takes the required values and add schedule related information to database
        public static string AddSchedule(addSchedule a)
        {
            try
            {
                var b = from L in d.BusDetails_Table
                        where L.Bus_ID == a.Bid
                        select L;
                var s = from K in d.Schedule_Table
                        select K;
                List<Schedule_Table> sc = s.ToList();
                int flag = 0;
                foreach (var c in sc)
                {
                    if (a.Doj == c.DateOfJourney && a.Bid == c.Bus_ID)
                    {
                        flag = 1;
                        break;
                    }
                }
                BusDetails_Table B = b.FirstOrDefault();
                if (B.Capacity >= a.Capacity)
                {
                    if (flag == 0)
                    {
                        int sid = (from r in d.Schedule_Table
                                   select r).Count() + 1;
                        Schedule_Table Sh = new Schedule_Table();
                        Sh.SID = "S" + sid;
                        Sh.Route_ID = a.Rid;
                        Sh.Bus_ID = a.Bid;
                        Sh.StartTime = a.StartTime.TimeOfDay;
                        Sh.DateOfJourney = a.Doj;
                        Sh.AvailableSeats = a.Capacity;
                        d.Schedule_Table.Add(Sh);
                        d.SaveChanges();
                        return "Schedule created with Schedule id " + Sh.SID;
                    }
                    else
                        return "Journey already exist";
                }
                else
                    return "Available seats are more than capacity";
            }
            catch (DbUpdateException E)
            {
                SqlException ex = E.GetBaseException() as SqlException;
            }
            return null;


        }
        //extract information about customer booking using history stored procedure
        //returns result as list
        public static List<history_Result> FindHistory(int cid)
        {
            try
            {
                ObjectResult<history_Result> ob = d.history(cid);
                List<history_Result> L = ob.ToList();
                return L;
            }
            catch (DbUpdateException E)
            {
                SqlException ex = E.GetBaseException() as SqlException;
            }
            return null;

        }
        //extract information about routes and date provided by customer
        //using SP_Test stored procedure
        //returns result as list
        public static List<SP_Test_Result> FindTickets(bookTickets B)
        {
            try
            {
                ObjectResult<SP_Test_Result> ob1 = d.SP_Test(B.From, B.To, B.Starttime, B.Not);
                List<SP_Test_Result> L1 = ob1.ToList();
                return L1;
            }
            catch (DbUpdateException E)
            {
                SqlException ex = E.GetBaseException() as SqlException;
            }
            return null;

        }
        //confirms the ticket by putting data in Booking_Table
        //reduces the number of available tickets
        //returns string to show confirmation
        public static string BookTicket(string sid, int seats,int cid)
        {
            try
            {
                var r = (from L in d.Schedule_Table
                         where L.SID == sid
                         select L).FirstOrDefault();
                Schedule_Table S = r;
                string bid = S.Bus_ID;
                if (S.AvailableSeats < seats)
                {
                    return "Sorry , no seats left";
                }
                else
                {
                    S.AvailableSeats = S.AvailableSeats - seats;
                    d.SaveChanges();
                }
                string day = DateTime.Now.ToString("dd");
                string month = DateTime.Now.ToString("MM");
                string year = DateTime.Now.ToString("yy");
                int bno = (from rno in d.Booking_Table
                           select rno).Count() + 1;
                Booking_Table Bt = new Booking_Table();
                Bt.Customer_ID = cid;
                Bt.SID = sid;
                Bt.NoOfTickets = seats;
                Bt.Ticket_ID = bid + day + month + year + string.Format("{0:0000}", bno);
                d.Booking_Table.Add(Bt);
                d.SaveChanges();
                return "“Ticket Booked successfully";
            }
            catch (DbUpdateException E)
            {
                SqlException ex = E.GetBaseException() as SqlException;
                if (ex.Message.Contains("PK_Schedule_Table"))
                {
                    return "schedule id already exists";

                }
                if (ex.Message.Contains("PK_BusDetails_Table"))
                {
                    return "Bus id already exists";

                }

            }
            return null;
        }
        //returns list of ticket id against the current logged in user 
        public static List<Booking_Table> GetBookid(int cid)
        {
            try
            {
                var EN = from L in d.Booking_Table
                         where L.Customer_ID == cid
                         select L;
                return EN.ToList();
            }
            catch (DbUpdateException E)
            {
                SqlException ex = E.GetBaseException() as SqlException;
            }
            return null;
        }
        //takes ticket id as input and cancels the booking by removing required column in booking table
        //increments the available tickets
        //returns confirmation as a string with calculated refund item with respect to hours left to booking
        public static string CancelTicket(string bookid)
        {
            try
            {
                double amountRefund;
                var r = from L in d.Booking_Table
                        where L.Ticket_ID == bookid
                        select L;
                Booking_Table B = r.FirstOrDefault();
                string sid = B.SID;
                int not = B.NoOfTickets;

                var s = from L1 in d.Schedule_Table
                        where L1.SID == sid
                        select L1;
                Schedule_Table S = s.FirstOrDefault();
                string rid = S.Route_ID;
                DateTime dateOT = S.DateOfJourney;
                int timeOT = int.Parse(S.StartTime.TotalHours.ToString());
                DateTime todaydate = DateTime.Now;
                int age = (int)(dateOT.Subtract(todaydate).TotalHours);
                int hoursLeft = age + timeOT;
                var rt = from L2 in d.Route_Table
                         where L2.Route_ID == rid
                         select L2;
                Route_Table R = rt.FirstOrDefault();
                int cost = R.Cost;
                int TicketCost = cost * not;
                if (hoursLeft >= 48)
                {
                    amountRefund = TicketCost - (0.1 * TicketCost);
                }
                else if (hoursLeft < 48 && hoursLeft >= 24)
                {
                    amountRefund = TicketCost - (0.25 * TicketCost);
                }
                else if (hoursLeft < 24 && hoursLeft >= 12)
                {
                    amountRefund = TicketCost - (0.5 * TicketCost);
                }
                else
                    amountRefund = TicketCost - (1 * TicketCost);
                S.AvailableSeats = S.AvailableSeats + not;
                d.SaveChanges();
                d.Booking_Table.Remove(B);
                d.SaveChanges();
                return "Tickets Cancelled Successfully. Refund of Amount Rs:" + amountRefund + " inititated to Customer";
            }
            catch (DbUpdateException E)
            {
                SqlException ex = E.GetBaseException() as SqlException;
            }
            return null;

        }
        //returns single row of customer value using customer id of current logged in user
        public static Customer_Table GetCustomerInfo(int cid)
        {
            try
            {
                var c = from L in d.Customer_Table
                        where L.Customer_ID == cid
                        select L;
                return c.FirstOrDefault();
            }
            catch (DbUpdateException E)
            {
                SqlException ex = E.GetBaseException() as SqlException;
            }
            return null;
        }
        //gets the updated values and changes the value against current logged in user
        public static string updateCustomer(updateDetails C,int cid)
        {
            try
            {
                var c = from L in d.Customer_Table
                        where L.Customer_ID == cid
                        select L;
                Customer_Table CT = c.FirstOrDefault();
                CT.Name = C.Name;
                CT.Address = C.Address;
                CT.City = C.City;
                CT.Country = C.Country;
                CT.State = C.State;
                CT.Pincode = int.Parse(C.Pincode);
                CT.Email = C.Email;
                CT.Contactno = C.Contact;
                CT.CustomerType = C.Ctype;
                d.SaveChanges();
                return "Account Updated";
            }
            catch (DbUpdateException E)
            {
                SqlException ex = E.GetBaseException() as SqlException;
            }
            return null;
        }
        public static List<destination> senfFromTo()
        {
            try
            {
                var s = from L in d.destinations
                        select L;
                return s.ToList();
            }
            catch (DbUpdateException E)
            {
                SqlException ex = E.GetBaseException() as SqlException;
            }
            return null;
        }

    }
    
}