using CricStats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CricStats.Controllers
{
    public class CricketersController : Controller
    {
        CricketerDBContext db = new CricketerDBContext();
        // GET: Cricketers
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Welcome()
        {
            ViewBag.Message = "Imran Khan (PM)";
            return View();
        }
    }
}