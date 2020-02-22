using Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 作业1.Controllers
{
    public class AjaxController : Controller
    {
        itcastEntities itcast = new itcastEntities();

        // GET: Ajax
        public ActionResult Index()
        {           
            return View();
        }
        public ActionResult Indexs()
        {
            var user = itcast.User_info;
            return Json(user,JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(string Name,string Age,string Company)
        {
            User_info user = new User_info();
            user.Name = Name;
            user.Age =Convert.ToInt32( Age);
            user.Company = Company;
            //itcast.User_info.Add(user);
            itcast.Entry<User_info>(user).State = System.Data.Entity.EntityState.Added;
            int i= itcast.SaveChanges();
            if (i > 0)
            {
                return Content("true");
            }
            return Content("false");
            
        }

        public ActionResult Deleted(string Id)
        {
            User_info user = itcast.User_info.Find(Convert.ToInt32(Id));
            itcast.Entry<User_info>(user).State = System.Data.Entity.EntityState.Deleted;
            int i= itcast.SaveChanges();
            if (i > 0)
            {
                return Content("true");
            }
            return Content("false");
        }
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            User_info user = itcast.User_info.Find(Convert.ToInt32(Id));
            
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(string Id,string Name,string Age,string Company)
        {
            User_info user = new User_info() ;
            user.Id = Convert.ToInt32(Id);
            user.Name = Name;
            user.Age =Convert.ToInt32( Age);
            user.Company = Company;
            itcast.Entry<User_info>(user).State = System.Data.Entity.EntityState.Modified;
            int i= itcast.SaveChanges();
            if (i > 0)
            {
                return Content("true");
            }
            return Content("false");
            
        }

    }
}