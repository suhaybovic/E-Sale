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

        public List<Following> CheckFollowing(int Companyid,int userid)
        {
            var x = from s in context.Followings
                    where s.CompanyID == Companyid
                    where s.UserID == userid
                    select s;

            return x.ToList();
        }

        
        public List<Post> getHomeposts(int id)
        {
            var things = from Posts in context.Posts
                         join Following in context.Followings on Posts.CompanyID equals Following.CompanyID
                         where Following.UserID == id
                         select Posts;
                return things.ToList();
        }
        public List<Company> getFollowedCompanies(int id)
        {
                var things = from s in context.Followings
                             where s.UserID==id
                         select s.Company;

                return things.ToList();
        }

        
        
    }
}
