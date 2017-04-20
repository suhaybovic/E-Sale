using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Sale.ViewModel;
namespace E_Sale.Controllers
{
    public class PostController : Controller
    {
        DbCenter.Util.DBCenterContext context = new DbCenter.Util.DBCenterContext();
     
        //
        // GET: /Post/
        [HttpPost]
        public ActionResult Like(int id)
        {
            DbCenter.ModelClasses.Like like = new DbCenter.ModelClasses.Like();
            like.PostID = id;
            like.UserID = (int)Session["UserID"];
            context.Likes.Add(like);
            context.SaveChanges();
            return new HttpStatusCodeResult(200);
        } 


        [HttpPost]
        public ActionResult CheckLike(int id)
        {
            int UserID = (int)Session["UserID"];

            var x = from s in context.Likes
                                           where s.PostID == id
                                           where s.UserID == UserID
                                           select s;

            List<DbCenter.ModelClasses.Like> t = x.ToList();
                
            if(t.Any())
                return new HttpStatusCodeResult(200);
            return new HttpStatusCodeResult(404);
        } 
        
	}
}