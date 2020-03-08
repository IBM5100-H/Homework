﻿using Movies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 作业1.Controllers
{
    public class LayerUIController : Controller
    {
        // GET: LayerUI
        MovieEntities MovieEntities = new MovieEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read(int page, int limit)
        {
            var list = MovieEntities.VMovieses;
            Hashtable ht = new Hashtable();
            ht["code"] = 0;
            ht["msg"] = "";
            ht["count"] = list.Count();
            ht["data"] = list.SqlQuery("select top ("+ limit + ") * from(select row_number()over(order by  mid) as rownumber, *from [VMovieses]) temp_row where rownumber > ((" + page+ " - 1) * " + limit + ")").ToList();

            return Json(ht, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Del(string id)
        {
            Hashtable ht = new Hashtable();
            var movie = MovieEntities.Movie.Find(Convert.ToInt32(id));
            if (movie != null)
            {
                MovieEntities.Movie.Remove(movie);
                MovieEntities.SaveChanges();
                ht["message"] = "删除成功";
                ht["result"] = "ture";
            }
            else
            {
                ht["message"] = "删除失败";
            }
            return Json(ht);
        }

        public ActionResult Edit()
        {
            ViewBag.country = MovieEntities.country;
            ViewBag.movietype = MovieEntities.movietype;    

            return View();
        }
    }
}