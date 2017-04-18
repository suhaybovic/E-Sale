using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Sale.Models
{
    public class MVCCompany
    {
        public MVCCompany()
        {
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Field { get; set; }
        public Nullable<int> ProfilePhoto { get; set; }
        public string Password { get; set; }
        public Nullable<int> AddressID { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }

        public virtual MVCAddress Address { get; set; }
        public virtual MVCPhoto Photo { get; set; }

    }
}