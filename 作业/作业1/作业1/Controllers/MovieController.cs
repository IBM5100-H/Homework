using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies;



namespace 作业1.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        itcastEntities itcast = new itcastEntities();
        public ActionResult Index()
        {
            var list = itcast.User_info;
            return View(list);
        }

        public ActionResult Delete(string Id)
        {
            var user = itcast.User_info.Find(Convert.ToInt32(Id));
            if (user != null)
            {
                itcast.User_info.Remove(user);
                itcast.SaveChanges();
                return Content("<script>alert('删除成功');window.location.href='/Movie/Index'; </script>");
            }
            else
            {
                return Content("<script>alert('删除失败');window.location.href='/Movie/Index'; </script>");
            }
        }

        [HttpGet]
        public ActionResult Edit(string Id)
        {
            var user = itcast.User_info.Find(Convert.ToInt32(Id));
            if (user != null)
            {
                return View(user);
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(User_info user_Info)
        {
            var user = itcast.User_info.Find(user_Info.Id);
            if (user != null)
            {
                user.Name = user_Info.Name;
                user.Age = user_Info.Age;
                user.Company = user_Info.Company;
                UpdateModel(user);
                itcast.SaveChanges();
                return Content("<script>alert('修改成功');window.location.href='/Movie/Index'; </script>");
            }
            return Content("<script>alert('修改失败');window.location.href='/Movie/Index'; </script>");
        }


        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(User_info user_Info)
        {
            itcast.User_info.Add(user_Info);
            itcast.SaveChanges();
            return Content("<script>alert('添加成功');window.location.href='/Movie/Index'; </script>");
        }

    }
}