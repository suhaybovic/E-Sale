using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using E_Sale.Models;
using System.Data.Entity;
using DbCenter.Util;

namespace E_Sale
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            System.Data.Entity.Database.SetInitializer<DBCenterContext>(new Initializer());
            using (var context = new DBCenterContext())
            {
                context.Database.Initialize(force: true);
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            E_Sale.AutoMapper.AutoMapperApplication.AutoMapper();
        }
    }
}
