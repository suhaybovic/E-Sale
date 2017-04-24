using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DbCenter.ModelClasses;
using DbCenter.Util;
using DbCenter.DbCenterOtherModelFunctions;
namespace E_Sale.Models
{
    public class ESaleContext : DbContext
    {
        DBCenterContext context = new DBCenterContext();
        public ESaleContext() : base("DB")
        {
            E_Sale.AutoMapper.AutoMapperApplication.AutoMapperinit();
        }

        public void AddFollowing(Following following)
        {
            context.Add(following);
            context.saveChanges();
        }

        public void AddCompany(Company company)
        {
            context.Add(company);
            context.saveChanges();
        }
        public DbCenter.ModelClasses.Photo AddPhoto(Photo photo)
        {
            var temp = context.Add(photo);
            context.saveChanges();
            return temp;
        }
        public void AddProduct(Product product)
        {
            context.Add(product);
            context.saveChanges();
        }
        public void AddUser(User user)
        {
            context.Add(user);
            context.saveChanges();
        }
        public void AddPost(Post post)
        {
            context.Add(post);
            context.saveChanges();
        }
        public List<Company> LoginCompany(Company company)
        {
            CompanyFunctions CompanyFunctions = new CompanyFunctions();
            return CompanyFunctions.LoginCompany(company);
        }

        public List<User> LoginUser(User user)
        {
            UserFunctions userFunctions = new UserFunctions();
            return userFunctions.LoginUser(user);
        }

        public User getUserByID(int id)
        {
            return context.getUserByID(id);
        }

        public Product getProductByID(int id)
        {
            return context.getProductByID(id);
        }

        public Company getCompanyByID(int id)
        {
            return context.getCompanyByID(id);
        }

        public List<Product> getProductsForCompany(int id)
        {
            return context.getProductsForCompany(id);
        }

        public List<Product> getProductsbyType(string type)
        {
            return context.getProductsbyType(type);
        }
        
        public List<Post> getPostsForCompany(int id)
        {
            return context.getPostsForCompany(id);
        }
        public List<Post> getPostsForUser(int id)
        {
            return context.getPostsForUser(id);
        }
        public List<Post> getHomeposts(int id)
        {
            UserFunctions userFunctions = new UserFunctions();
            return userFunctions.getHomeposts(id);
        }
        public List<Company> getFollowedCompanies(int id)
        {
            
            UserFunctions userFunctions = new UserFunctions();
            return userFunctions.getFollowedCompanies(id);
            
        }
        
        public List<Following> CheckFollowing(int Companyid, int userid)
        {
            UserFunctions userFunctions = new UserFunctions();
            return userFunctions.CheckFollowing(Companyid,userid);
        }

        public System.Data.Entity.DbSet<E_Sale.Models.MVCProduct> MVCProducts { get; set; }

        public System.Data.Entity.DbSet<E_Sale.Models.MVCCompany> MVCCompanies { get; set; }

        public System.Data.Entity.DbSet<E_Sale.Models.MVCPhoto> MVCPhotoes { get; set; }

        
        
        
        
    }
}