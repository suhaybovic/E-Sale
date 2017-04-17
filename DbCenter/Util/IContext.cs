using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCenter.Util
{
    interface IContext
    {
        T Add<T>(T entity) where T : class;
        int saveChanges();
    }
}
