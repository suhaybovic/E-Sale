using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Sale.Models;

namespace E_Sale.ViewModel
{
    public class NewsViewModel
    {
        public MVCCompany Company { get; set; }
        public string Text { get; set; }

        public virtual List<MVCPost> Posts{ get; set; }
    }
}