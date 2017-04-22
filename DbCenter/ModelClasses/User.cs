using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCenter.ModelClasses
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Nullable<int> ProfilePhotoID { get; set; }
        public Nullable<int> AddressID { get; set; }

        public virtual Address Address { get; set; }
        public virtual Photo ProfilePhoto { get; set; }

        public virtual ICollection<Friend> Friends1 { get; set; }
        public virtual ICollection<Friend> Friends2 { get; set; }

    }
}
