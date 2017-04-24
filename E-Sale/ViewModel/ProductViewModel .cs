using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Sale.Models;
using System.Web.Mvc;

namespace E_Sale.ViewModel
{
    public class ProductViewModel
    {
        public MVCCompany Company { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public String ProductType { get; set; }


        public virtual List<MVCProduct> Products { get; set; }
    }

}