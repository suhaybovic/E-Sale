using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Sale.Models;
using E_Sale.ViewModel;
using System.IO;

namespace E_Sale.Controllers
{
    public class CompanyController : Controller
    {
        ESaleContext Entities = new ESaleContext();

        public ActionResult Home(int id)
        {
            var result =1;
            /* var result = from s in Entities.Companies
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
             * */
            return null;
        }

        public ActionResult Product(int id)
        {
            /*
            var result = from s in Entities.Companies
                         where s.ID == id
                         select s;

            if (!result.Any())
            {
                return null;
            }
            else
            {
                ProductViewModel ProductViewModel = new ProductViewModel();
                ProductViewModel.ID = id;
                ViewBag.id = id;
                return View(ProductViewModel);
            }
             * */

            return null;
        }

        [HttpPost]
        public ActionResult Product(ProductViewModel ProductViewModel,HttpPostedFileBase image)
        {
            string path = Path.Combine(Server.MapPath("~/assets/Uploaded_photos"),Path.GetFileName(image.FileName));
            image.SaveAs(path);

            Photo photo = new Photo();
            photo.URL = "assets/Uploaded_photos/"+image.FileName;
           // Entities.Photos.Add(photo);
            Entities.SaveChanges();
            var photoid = photo.ID;

            Product product = new Product();
            product.CompanyID = (int)Session["CompanyID"];
            product.Name = ProductViewModel.Name;
            product.Price = ProductViewModel.Price;
            product.Description = ProductViewModel.Description;
            product.PhotoID = photoid;
            product.Photo = photo;
            //Entities.Products.Add(product);
            Entities.SaveChanges();

            return RedirectToAction("Product");
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
            /*
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
                Session["CompanyID"] =  result.First().ID;
                return RedirectToAction("Index", "Home");
            }
             * */
            return null;
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

           // Entities.Companies.Add(company);
            Entities.SaveChanges();

            return View();
        }
	}
}