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
        public ActionResult Index()
        {
            itcastEntities itcast = new itcastEntities();
            var list = itcast.User_info;
            return View(list);
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}