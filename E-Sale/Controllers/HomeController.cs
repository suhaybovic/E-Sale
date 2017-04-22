using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Sale.Models;
using E_Sale.ViewModel;
using AutoMapper;
namespace E_Sale.Controllers
{
    public class HomeController : Controller
    {
        ESaleContext ESaleContext = new ESaleContext();

        public ActionResult Index()
        {
            if (Session["Type"] == null)
            { 
                return View("Start");
            }
            else
            {
                HomeViewModel homeViewModel = new HomeViewModel();

                var usermvc = ESaleContext.getUserByID((int)Session["UserID"]);
                homeViewModel.user = Mapper.Map<MVCUser>(usermvc);

                var FollwedCompanies = ESaleContext.getFollowedCompanies((int)Session["UserID"]);
                homeViewModel.FollowedCompanies = Mapper.Map<List<MVCCompany>>(FollwedCompanies);


                var HomePosts = ESaleContext.getHomeposts((int)Session["UserID"]);
                homeViewModel.FollowedCompaniesPosts = Mapper.Map<List<MVCPost>>(HomePosts);

                return View("Index", homeViewModel);

            }
        }
        

    }
}