using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DbCenter.Util;
namespace E_Sale.Models
{
    public class ESaleContext : DbContext
    {
        DBCenterContext context = new DBCenterContext();
        public ESaleContext() : base("DB")
        {
            
        }
    }
}