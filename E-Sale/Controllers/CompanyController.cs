﻿using System;
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
                cfg.CreateMap<DbCenter.ModelClasses.Company, MVCCompany>().ForMember(dst => dst.Address, src => src.Ignore()).
                    ForMember(dst => dst.Photo, src => src.Ignore());
            });
            var companyDto = Mapper.Map<MVCCompany>(company);


            if (companyDto == null)
             {
                 return null;
             }
             else
             {
                 return View(companyDto);
             }
        }

        public ActionResult News(int id)
        {
            DbCenter.ModelClasses.Company company = ESaleContext.getCompanyByID(id);

            var companyDto = ContextMapper.MaptoMVCCompany(company);

            if (companyDto == null)
            {
                return null;
            }
            else
            {
                if (Session["CompanyID"] == null)
                    ViewBag.id = null;
                else
                {
                    ViewBag.Type = Session["Type"];
                    ViewBag.id = (int)Session["CompanyID"];
                }
                NewsViewModel NewsViewModel = new NewsViewModel();
                NewsViewModel.Company = companyDto;
                var t = ESaleContext.getPostsForCompany(id);
                NewsViewModel.Posts = ContextMapper.MaptoMVCPostList(t);

                return View(NewsViewModel);
            }

        }


        [HttpPost]
        public ActionResult News(NewsViewModel NewsViewModel, HttpPostedFileBase image)
        {
            DbCenter.ModelClasses.Photo photoreturned = null;
            if(image!=null)
            { 
                string path = Path.Combine(Server.MapPath("~/assets/Uploaded_photos"), Path.GetFileName(image.FileName));
                image.SaveAs(path);

                DbCenter.ModelClasses.Photo photo = new DbCenter.ModelClasses.Photo();
                photo.URL = "assets/Uploaded_photos/" + image.FileName;
                photoreturned = ESaleContext.AddPhoto(photo);
            }
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<NewsViewModel, DbCenter.ModelClasses.Post>()
                .ForMember(dst => dst.Company, src => src.Ignore());
            });

            var post = Mapper.Map<DbCenter.ModelClasses.Post>(NewsViewModel);

            post.CompanyID = (int)Session["CompanyID"];
            post.Company = ESaleContext.getCompanyByID((int)Session["CompanyID"]);
            if (image != null)
                post.PhotoID = photoreturned.ID;
            else
                post.PhotoID =null;
            post.CreationDate = DateTime.Now;

            ESaleContext.AddPost(post);


            return RedirectToAction("News");
        }

        public ActionResult Product(int id)
        {
            DbCenter.ModelClasses.Company company = ESaleContext.getCompanyByID(id);

            var companyDto = ContextMapper.MaptoMVCCompany(company);

            if (companyDto == null)
            {
                return null;
            }
            else
            {
                if (Session["CompanyID"] == null)
                    ViewBag.id = null;
                else
                    ViewBag.id = (int)Session["CompanyID"];
                ProductViewModel ProductViewModel = new ProductViewModel();
                ProductViewModel.Company = companyDto;
                var t = ESaleContext.getProductsForCompany(id);
                ProductViewModel.Products = ContextMapper.MaptoMVCProductList(t);
                return View(ProductViewModel);
            }

        }

        [HttpPost]
        public ActionResult Product(ProductViewModel ProductViewModel,HttpPostedFileBase image)
        {
            string path = Path.Combine(Server.MapPath("~/assets/Uploaded_photos"),Path.GetFileName(image.FileName));
            image.SaveAs(path);

            DbCenter.ModelClasses.Photo photo = new DbCenter.ModelClasses.Photo();
            photo.URL = "assets/Uploaded_photos/"+image.FileName;
            var photoreturned = ESaleContext.AddPhoto(photo);
            
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductViewModel, DbCenter.ModelClasses.Product>()
                .ForMember(dst => dst.Company, src => src.Ignore());
            });
            var product = Mapper.Map<DbCenter.ModelClasses.Product>(ProductViewModel);

            product.CompanyID = (int)Session["CompanyID"];
            product.PhotoID = photoreturned.ID;
            ESaleContext.AddProduct(product);

            return RedirectToAction("Product");
        }


        public ActionResult Login()
        {
            MVCCompany viewmodel = new MVCCompany();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Login(MVCCompany company)
        {
            var companyDto = ContextMapper.MaptoDbcenterCompany(company);
            var result = ESaleContext.LoginCompany(companyDto);

            if (!result.Any())
            {
                return RedirectToAction("Index");
            }
            else
            {
                Session["CompanyID"] = result.First().ID;
                Session["Type"] = "Company";
                return RedirectToAction("Index", "Home");
            }
        }



        public ActionResult SignUp()
        {
            MVCCompany viewmodel = new MVCCompany();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult SignUp(MVCCompany company)
        {
            var companyDto = ContextMapper.MaptoDbcenterCompany(company);
            ESaleContext.AddCompany(companyDto);
            ESaleContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }
	}
}