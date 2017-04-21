using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            DbCenter.ModelClasses.User userDto = null;
            Mapper.Map(User, userDto);
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
            DbCenter.ModelClasses.User userDto = Mapper.Map<DbCenter.ModelClasses.User>(user);
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


	}
}