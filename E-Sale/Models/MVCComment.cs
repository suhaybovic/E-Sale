using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Sale.Models
{
    public class MVCComment
    {
        public string ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> PostID { get; set; }
        public string Text { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }

        public virtual MVCPost Post { get; set; }
        public virtual MVCUser User { get; set; }
    }
}