using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team4.Models
{
    public class userBus
    {
        static Team4Entities T = new Team4Entities();
        //search the suppllied username and password in Login_Table
        //returns row if values are found
        public static Login_Table search(string user, string pass)
        {
            var E = (from L in T.Login_Table
                     where L.User_ID == user && L.Password == pass
                     select L).FirstOrDefault();   
            
                return E;                        
        }
        //sends list of country from CS_Table
        public static List<string> SendCnames()
        {
            var C = (from C1 in T.CS_Table
                     select C1.Country).Distinct();

            return C.ToList();
        }
        //sends list of states from CS_Table against country
        public static List<string> SendStates(string Country)
        {
            var C = (from C1 in T.CS_Table
                     where C1.Country == Country
                     select C1.State);

            return C.ToList();
        }
        //insert selected values to Login_Table during registration
        public static regValidation insertLogin(regValidation C)
        {

            Login_Table l = new Login_Table();
            l.User_ID = C.CustomeriD;
            l.Password = C.Password;
            l.UserType = "Customer";
            T.Login_Table.Add(l);
            T.SaveChanges();

            return C;

        }
        //insert values to Customer_Table after generating customer ID
        public static string insertCustomer(regValidation C)
        {

            Customer_Table C1 = new Customer_Table();
            int r = (from c in T.Customer_Table
                     select c).Count() + 1;
            DateTime dt = DateTime.Today;
            C.CustomeriD = dt.Year.ToString() +string.Format("{0:00}",dt.Month) + string.Format("{0:0000}", r);
            C1.Customer_ID = int.Parse(C.CustomeriD);
            C1.Name = C.Name;
            C1.Address = C.Address;
            C1.City = C.City;
            C1.State = C.State;
            C1.Country = C.Country;
            C1.Pincode = int.Parse(C.Pincode);
            C1.Email = C.Email;
            C1.Gender = C.Gender;
            C1.Contactno = C.Contact;
            C1.DateOfBirth = C.Dob;
            C1.CustomerType = C.Ctype;
            T.Customer_Table.Add(C1);
            T.SaveChanges();
            return "Sucessfully Registered";

        }
    }
}