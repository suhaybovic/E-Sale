using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Sale.Models;
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
            var userDto = ContextMapper.MaptoDbcenterUser(User);
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
            var userDto = ContextMapper.MaptoDbcenterUser(user);
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