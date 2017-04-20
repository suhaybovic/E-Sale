using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCenter.ModelClasses
{
    public class Address
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string Area { get; set; }
        public string Street { get; set; }


        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
