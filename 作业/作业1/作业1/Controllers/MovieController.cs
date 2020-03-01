using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies;
using Webdiyer.WebControls.Mvc;


namespace 作业1.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        itcastEntities itcast = new itcastEntities();

        public ActionResult Index(string AdressId, string OccupationId, int tid=1)
        {


            #region linq lambda sql
            //var list = itcast.Database.SqlQuery<MovieDetailMV>("");

            //var list = itcast.User_info;
            var linqlist = from m in itcast.User_info
                           join t in itcast.Adress on m.AdressId equals t.AdressId
                           select new MovieDetailMV
                           {
                               Id = m.Id,
                               AdressId = t.AdressId,
                               Name = m.Name,
                               Age = m.Age,
                               Company = m.Company,
                               AdressName = t.AdressName

                           };

            var lambda = itcast.User_info.Join(itcast.Adress, m => m.AdressId, t => t.AdressId, (m, t) => new MovieDetailMV()
            {
                Id = m.Id,
                AdressId = t.AdressId,
                Name = m.Name,
                Age = m.Age,
                Company = m.Company,
                AdressName = t.AdressName
            }
                );
            #endregion

            var adress = itcast.Adress;
            ViewBag.adress = adress;
            var occupation = itcast.occupation;
            ViewBag.occupation = occupation;
            ViewBag.OccupationId = "0";
            ViewBag.AdressId = "0";

            var vmodel = itcast.VMovie.ToList(); ;
            string Name = Request.Form["txtName"];
            string Age = Request.Form["txtAge"];
            if (!string.IsNullOrEmpty(Name))
            {
                vmodel = vmodel.Where(m => m.Name.Contains(Name)).ToList();
            }
            if (!string.IsNullOrEmpty(Age))
            {
                vmodel = vmodel.Where(m => m.Age ==Convert.ToInt32( Age)).ToList();
            }


            if (!string.IsNullOrEmpty(AdressId) && AdressId!= ViewBag.AdressId && AdressId != "null")
            {             
                    vmodel = vmodel.Where(m => m.AdressId == Convert.ToInt32(AdressId)).ToList();
                    ViewBag.AdressId = AdressId;                  

            }
            if (!string.IsNullOrEmpty(OccupationId)&& OccupationId!= ViewBag.OccupationId && OccupationId != "null")
            {             
                vmodel = vmodel.Where(m => m.OccupationId == Convert.ToInt32(OccupationId)).ToList();
                ViewBag.OccupationId = OccupationId;
            }


            return View(vmodel.ToPagedList(tid,5));
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