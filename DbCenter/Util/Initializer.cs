using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCenter.Util
{
    public class Initializer : CreateDatabaseIfNotExists<DBCenterContext>
    {
        protected override void Seed(DBCenterContext context)
        {
            base.Seed(context);
            DbCenter.ModelClasses.Company c = new ModelClasses.Company();
            c.Email = "Suhaybovic@gmail.com";
            c.Password = "123456";
            context.Companies.Add(c);
            context.saveChanges();
        }
    }
}
