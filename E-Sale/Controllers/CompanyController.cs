using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Sale.Models;
using E_Sale.ViewModel;
using System.IO;
using AutoMapper;
namespace E_Sale.Controllers
{
    public class CompanyController : Controller
    {
        ESaleContext ESaleContext = new ESaleContext();

        public ActionResult Home(int id)
        {
            DbCenter.ModelClasses.Company company = ESaleContext.getCompanyByID(id);
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DbCenter.ModelClasses.Company, Company>().ForMember(dst => dst.Address, src => src.Ignore()).
                    ForMember(dst => dst.Photo, src => src.Ignore());
            });
            var companyDto = Mapper.Map<Company>(company);


            if (companyDto == null)
             {
                 return null;
             }
             else
             {
                 return View(companyDto);
             }
        }

        public ActionResult Product(int id)
        {
            /*
            var result = from s in ESaleContext.Companies
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
           // ESaleContext.Photos.Add(photo);
            ESaleContext.SaveChanges();
            var photoid = photo.ID;

            Product product = new Product();
            product.CompanyID = (int)Session["CompanyID"];
            product.Name = ProductViewModel.Name;
            product.Price = ProductViewModel.Price;
            product.Description = ProductViewModel.Description;
            product.PhotoID = photoid;
            product.Photo = photo;
            //ESaleContext.Products.Add(product);
            ESaleContext.SaveChanges();

            return RedirectToAction("Product");
        }


        public ActionResult Login()
        {
            Company viewmodel = new Company();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Login(Company company)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Company, DbCenter.ModelClasses.Company>().ForMember(dst => dst.Address, src => src.Ignore()).
                    ForMember(dst => dst.Photo, src => src.Ignore());
            });
            var companyDto = Mapper.Map<DbCenter.ModelClasses.Company>(company);
            var result = ESaleContext.LoginCompany(companyDto);

            if (!result.Any())
            {
                return RedirectToAction("Index");
            }
            else
            {
                Session["CompanyID"] =  result.First().ID;
                return RedirectToAction("Index", "Home");
            }
        }



        public ActionResult SignUp()
        {
            Company viewmodel = new Company();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult SignUp(Company company)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Company, DbCenter.ModelClasses.Company>().ForMember(dst => dst.Address, src => src.Ignore()).
                    ForMember(dst => dst.Photo, src => src.Ignore());
            });
            var companyDto = Mapper.Map<DbCenter.ModelClasses.Company>(company);

            ESaleContext.AddCompany(companyDto);
            ESaleContext.SaveChanges();

            return View();
        }
	}
}