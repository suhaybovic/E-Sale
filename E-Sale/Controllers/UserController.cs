using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbCenter.ModelClasses;
using E_Sale.Models;
using AutoMapper;

namespace E_Sale.Controllers
{
    public class UserController : Controller
    {
        ESaleContext ESaleContext = new ESaleContext();

        public ActionResult SignUp()
        {
            MVCUser viewmodel = new MVCUser();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult SignUp(MVCUser User)
        {
            User userDto = Mapper.Map<DbCenter.ModelClasses.User>(User);
            ESaleContext.AddUser(userDto);
            ESaleContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            MVCUser viewmodel = new MVCUser();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Login(MVCUser user)
        {
            User userDto = Mapper.Map<User>(user);
            var result = ESaleContext.LoginUser(userDto);

            if (!result.Any())
            {
                return RedirectToAction("Index");
            }
            else
            {
                Session["UserID"] = result.First().ID;
                Session["Type"] = "User";
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpPost]
        public ActionResult FollowCompany(int id)
        {
            E_Sale.AutoMapper.AutoMapperApplication.AutoMapperinit();
            MVCFollowing follow = new MVCFollowing();
            follow.CompanyID = id;
            follow.UserID = (int)Session["UserID"];

            var following = Mapper.Map<Following>(follow);

            ESaleContext.AddFollowing(following);
            return new HttpStatusCodeResult(200);
        }


        [HttpPost]
        public ActionResult CheckFollowing(int id)
        {

            int UserID = (int)Session["UserID"];

            List<DbCenter.ModelClasses.Following> t = ESaleContext.CheckFollowing(id, UserID);
            
            if (t.Any())
                return new HttpStatusCodeResult(200);
            return new HttpStatusCodeResult(404);
        } 


	}
}