using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Sale.Models;

namespace E_Sale.ViewModel
{
    public class HomeViewModel
    {
        public virtual MVCUser user { get; set; }
        public virtual List<MVCPost> Posts { get; set; }
        public virtual List<MVCCompany> FollowedCompanies { get; set; }
        public virtual List<MVCPost> FollowedCompaniesPosts { get; set; }
    }
}