using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbCenter.Util;
using DbCenter.ModelClasses;
namespace DbCenter.DbCenterOtherModelFunctions
{
    public class CompanyFunctions
    {
        DBCenterContext context = new DBCenterContext();

       
        public List<Company> LoginCompany(Company company)
        {
            var result = from s in context.Companies
                         where s.Email.Equals(company.Email, StringComparison.OrdinalIgnoreCase)
                         where s.Password == company.Password
                         select s;
            return result.ToList();
        }
    }
}
