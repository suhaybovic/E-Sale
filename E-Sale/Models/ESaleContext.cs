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
            return CompanyFunctions.getCompanyByID(id);
        }
        public void AddCompany(DbCenter.ModelClasses.Company company)
        {
            context.Add(company);
            context.saveChanges();
        }
        public List<DbCenter.ModelClasses.Company> LoginCompany(DbCenter.ModelClasses.Company company)
        {
            CompanyFunctions CompanyFunctions = new CompanyFunctions();
            return CompanyFunctions.LoginCompany(company);
        }
    }
}