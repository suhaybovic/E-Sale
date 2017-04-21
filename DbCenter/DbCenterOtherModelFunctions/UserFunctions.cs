using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbCenter.ModelClasses;
using DbCenter.Util;

namespace DbCenter.DbCenterOtherModelFunctions
{
    public class UserFunctions
    {
        DBCenterContext context = new DBCenterContext();


        public List<User> LoginUser(User user)
        {
                var things = from s in context.Users
                         where s.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase)
                         where s.Password == user.Password
                         select s;

                return things.ToList();
           
            
        }
    }
}
