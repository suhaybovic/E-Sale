using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Sale.Models;
using E_Sale.ViewModel;

namespace E_Sale.Controllers
{
    public class CompanyController : Controller
    {
        Entities2 Entities = new Entities2();

        public ActionResult Home(int id)
        {
            var result = from s in Entities.Companies
                         where s.ID == id
                         select s;

            if (!result.Any())
            {
                return null;
            }
            else
            {
                return View(result.First());
            }
        }

        public ActionResult Product(int id)
        {
            var result = from s in Entities.Companies
                         where s.ID == id
                         select s;

            if (!result.Any())
            {
                return null;
            }
            else
            {
                return View(result.First());
            }
        }




        public ActionResult Login()
        {
            LoginCompanyViewModel viewmodel = new LoginCompanyViewModel();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Login(LoginCompanyViewModel LoginCompanyViewModel)
        {
            LoginCompanyViewModel viewmodel = new LoginCompanyViewModel();
            var result = from s in Entities.Companies
                         where s.Email == LoginCompanyViewModel.Email
                         where s.Password == LoginCompanyViewModel.Password
                         select s;

            if (!result.Any())
            {
                return RedirectToAction("Index");
            }
            else
            {
                this.Session["CompanyID"] = "" + result.First().ID;
                return View();
            }
        }





        public ActionResult SignUp()
        {
            SignUpViewModel viewmodel = new SignUpViewModel();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult SignUp(SignUpViewModel SignUpViewModel)
        {
            Company company = new Company();
            string temp = SignUpViewModel.field.ToString();
            company.Name = SignUpViewModel.Name;
            company.Password = SignUpViewModel.Password;
            company.Email = SignUpViewModel.Email;
            company.Field = temp;

            Entities.Companies.Add(company);
            Entities.SaveChanges();

            return View();
        }
	}
}