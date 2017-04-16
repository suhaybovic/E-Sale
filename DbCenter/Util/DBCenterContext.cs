using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DbCenter.ModelClasses;

namespace DbCenter.Util
{
   public class DBCenterContext : DbContext
    {
        public DBCenterContext(): base("DB")
        {
        }
        public DbSet<Address> Addresss { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
