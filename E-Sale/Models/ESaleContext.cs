using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DbCenter.Util;
using DbCenter.DbCenterOtherModelFunctions;
namespace E_Sale.Models
{
    public class ESaleContext : DbContext
    {
        DBCenterContext context = new DBCenterContext();
        public ESaleContext() : base("DB")
        {
        }
        public DbCenter.ModelClasses.Company getCompanyByID(int id)
        {
            CompanyFunctions CompanyFunctions = new CompanyFunctions();
            return context.getCompanyByID(id);
        }
        public void AddCompany(DbCenter.ModelClasses.Company company)
        {
            context.Add(company);
            context.saveChanges();
        }
        public DbCenter.ModelClasses.Photo AddPhoto(DbCenter.ModelClasses.Photo photo)
        {
            var temp = context.Add(photo);
            context.saveChanges();
            return temp;
        }
        public void AddProduct(DbCenter.ModelClasses.Product product)
        {
            context.Add(product);
            context.saveChanges();
        }
        public List<DbCenter.ModelClasses.Company> LoginCompany(DbCenter.ModelClasses.Company company)
        {
            CompanyFunctions CompanyFunctions = new CompanyFunctions();
            return CompanyFunctions.LoginCompany(company);
        }
        public List<DbCenter.ModelClasses.Product> getProductsForCompany(int id)
        {
            return context.getProductsForCompany(id);
        }
        
    }
}