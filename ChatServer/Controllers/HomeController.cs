using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Chat()
        {
            return View();
        }


        public ActionResult Chat2()
        {
            return View();
        }


        public ActionResult Chat3()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}