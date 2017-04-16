using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Sale.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
        public Nullable<int> ProfilePhoto { get; set; }
        public Nullable<int> Address { get; set; }


        public virtual Address Address1 { get; set; }
    }
}