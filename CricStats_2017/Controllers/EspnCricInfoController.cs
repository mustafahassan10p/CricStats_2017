using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CricStats.Models;

namespace CricStats.Controllers
{
    public class EspnCricInfoController : Controller
    {
        private CricketerDBContext db = new CricketerDBContext();

        // GET: EspnCricInfo
        public ActionResult Index(string CricketerGrade, string SearchName)
        {
            var cricketers = from cr in db.Cricketers select cr;
            var GradeList = new List<string>();
            var GradeQuery = from gq in db.Cricketers orderby gq.Grade select gq.Grade;
            GradeList.AddRange(GradeQuery.Distinct());
            ViewBag.CricketerGrade = new SelectList(GradeList);
            if (!String.IsNullOrEmpty(SearchName))
            {
                cricketers = cricketers.Where(c => c.Name.Contains(SearchName));
            }
            if (!string.IsNullOrEmpty(CricketerGrade))
            {
                cricketers = cricketers.Where(g => g.Grade == CricketerGrade);
            }
            return View(cricketers);
        }

        // GET: EspnCricInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer cricketer = db.Cricketers.Find(id);
            if (cricketer == null)
            {
                return HttpNotFound();
            }
            return View(cricketer);
        }

        // GET: EspnCricInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EspnCricInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,TestAvg,ODIAvg,T20Avg")] Cricketer cricketer)
        {
            if (ModelState.IsValid)
            {
                db.Cricketers.Add(cricketer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cricketer);
        }

        // GET: EspnCricInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer cricketer = db.Cricketers.Find(id);
            if (cricketer == null)
            {
                return HttpNotFound();
            }
            return View(cricketer);
        }

        // POST: EspnCricInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,TestAvg,ODIAvg,T20Avg")] Cricketer cricketer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cricketer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cricketer);
        }

        // GET: EspnCricInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer cricketer = db.Cricketers.Find(id);
            if (cricketer == null)
            {
                return HttpNotFound();
            }
            return View(cricketer);
        }

        // POST: EspnCricInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cricketer cricketer = db.Cricketers.Find(id);
            db.Cricketers.Remove(cricketer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
