using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Sale.Models
{
    public class MVCPost
    {
        public int ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string Text { get; set; }
        public Nullable<int> PhotoID { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }

        public virtual MVCCompany Company { get; set; }
        public virtual MVCPhoto Photo { get; set; }
        public virtual MVCUser User { get; set; }
    }
}