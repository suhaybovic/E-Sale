using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCenter.ModelClasses
{
    public class Company
    {
        public Company()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Field { get; set; }
        public Nullable<int> ProfilePhoto { get; set; }
        public string Password { get; set; }
        public Nullable<int> AddressID { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }

        public virtual Address Address { get; set; }
        public virtual Photo Photo { get; set; }
    }
}
