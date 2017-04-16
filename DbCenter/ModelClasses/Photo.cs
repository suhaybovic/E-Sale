using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCenter.ModelClasses
{
    public class Photo
    {
        public Photo()
        {
            this.Companies = new HashSet<Company>();
            this.Users = new HashSet<User>();
            this.Products = new HashSet<Product>();
        }

        public int ID { get; set; }
        public string URL { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
