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
        public string email { get; set; }
        public Nullable<int> ProfilePhoto { get; set; }
        public Nullable<int> AddressID { get; set; }

        public virtual ICollection<Following> Followings { get; set; }
        public virtual ICollection<Friend> Friends1 { get; set; }
        public virtual ICollection<Friend> Friends2 { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual Address Address { get; set; }
    }
}
