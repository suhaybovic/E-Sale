using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbCenter.ModelClasses;
using E_Sale.Models;
using AutoMapper;
using E_Sale.ViewModel;
using System.IO;

namespace E_Sale.Controllers
{
    public class UserController : Controller
    {
        ESaleContext ESaleContext = new ESaleContext();

        public ActionResult Home(int id)
        {
            UserHomeViewModel userHomeViewModel = new UserHomeViewModel();
            
            var user=ESaleContext.getUserByID(id);
            userHomeViewModel.User = Mapper.Map<MVCUser>(user);

            var posts = ESaleContext.getPostsForUser(id);
            userHomeViewModel.listofposts = Mapper.Map<List<MVCPost>>(posts);

            return View(userHomeViewModel);
        }


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
                @ViewBag.errorMessage = "Email And Password not matched !";
                return View();
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




        [HttpPost]
        public ActionResult News(HomeViewModel homeViewModel, HttpPostedFileBase image)
        {
            DbCenter.ModelClasses.Photo photoreturned = null;
            if (image != null)
            {
                string path = Path.Combine(Server.MapPath("~/assets/Uploaded_photos"), Path.GetFileName(image.FileName));
                image.SaveAs(path);

                DbCenter.ModelClasses.Photo photo = new DbCenter.ModelClasses.Photo();
                photo.URL = "assets/Uploaded_photos/" + image.FileName;
                photoreturned = ESaleContext.AddPhoto(photo);
            }

            var post = new DbCenter.ModelClasses.Post();

            post.UserID = (int)Session["UserID"];
            post.Text = homeViewModel.Text;
            post.CreationDate = DateTime.Now;

            if (image != null)
                post.PhotoID = photoreturned.ID;
            else
                post.PhotoID = null;

            ESaleContext.AddPost(post);
            return RedirectToAction("Index","Home");
        }


	}
}