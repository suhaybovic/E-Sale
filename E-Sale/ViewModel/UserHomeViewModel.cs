using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Sale.Models;
namespace E_Sale.ViewModel
{
    public class UserHomeViewModel
    {
        public virtual MVCUser User { get; set; }
        public List<MVCPost> listofposts { get; set; }
    }
}