using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CricStats.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your stats description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your cricstats contact page.";

            return View();
        }
    }
}