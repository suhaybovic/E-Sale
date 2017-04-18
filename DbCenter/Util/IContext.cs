using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbCenter.ModelClasses;
namespace DbCenter.Util
{
    interface IContext
    {
        T Add<T>(T entity) where T : class;
        Company getCompanyByID(int id);
        List<Product> getProductsForCompany(int id);
        int saveChanges();
    }
}
