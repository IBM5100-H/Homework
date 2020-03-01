using Movies;
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
        itcastEntities itcast = new itcastEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read()
        {
            var list = itcast.VMovie;
            Hashtable ht = new Hashtable();
            ht["code"] = 0;
            ht["msg"] = "";
            ht["count"] = list.Count();
            ht["data"] = list;
            return Json(ht, JsonRequestBehavior.AllowGet);
        }
    }
}