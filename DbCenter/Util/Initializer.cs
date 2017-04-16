using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCenter.Util
{
    public class Initializer : DropCreateDatabaseAlways<DBCenterContext>
    {
        protected override void Seed(DBCenterContext context)
        {
            base.Seed(context);
        }
    }
}
