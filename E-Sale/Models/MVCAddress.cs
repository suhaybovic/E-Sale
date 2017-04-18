using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Sale.Models
{
    public class MVCAddress
    {
        public MVCAddress()
        {
            this.Companies = new HashSet<MVCCompany>();
            this.Users = new HashSet<MVCUser>();
        }
    
        public int ID { get; set; }
        public string Country { get; set; }
        public string Area { get; set; }
        public string Street { get; set; }


        public virtual ICollection<MVCCompany> Companies { get; set; }
        public virtual ICollection<MVCUser> Users { get; set; }
    }
}