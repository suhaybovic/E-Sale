using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Sale.Models
{
    public class MVCFollowing
    {
        public int ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> CompanyID { get; set; }

        public virtual MVCCompany Company { get; set; }
        public virtual MVCUser User { get; set; }
    }
}
