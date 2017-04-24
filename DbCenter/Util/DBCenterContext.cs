using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DbCenter.ModelClasses;


namespace DbCenter.Util
{
   public class DBCenterContext : DbContext , IContext
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

        public T Add<T>(T entity) where T : class
        {
            return Set<T>().Add(entity);
              
        }

        public int saveChanges()
        {
            return SaveChanges();
        }
        public User getUserByID(int id)
        {
            return Users.Find(id);
        }

        public Product getProductByID(int id)
        {
            return Products.Find(id);
        }
        
       
        public Company getCompanyByID(int id)
        {
            return Companies.Find(id);
        }

        public List<Product> getProductsForCompany(int id)
        {
            return Products.Where(s => s.CompanyID == id).ToList();
        }
        public List<Product> getProductsbyType(string type)
        {
            return Products.Where(s => s.ProductType.Equals(type)).ToList();
        }

        public List<Post> getPostsForCompany(int id)
        {
            return Posts.Where(s => s.CompanyID == id).ToList();
        }
        public List<Post> getPostsForUser(int id)
        {
            return Posts.Where(s => s.UserID == id).ToList();
        }
       
       
    }
}
