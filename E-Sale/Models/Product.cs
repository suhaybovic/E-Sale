using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Sale.Models
{
    public class Product
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> PhotoID { get; set; }

        public virtual Company Company { get; set; }
        public virtual Photo Photo { get; set; }
    }
}