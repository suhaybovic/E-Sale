using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Sale.Models
{
    public class MVCProduct
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> PhotoID { get; set; }

        public virtual MVCCompany Company { get; set; }
        public virtual MVCPhoto Photo { get; set; }
    }
}