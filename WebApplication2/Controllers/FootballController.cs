using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class FootballController : Controller
    {
        // GET: Football
        private FootballContext db = new FootballContext();

        // GET: Footballs
        public ActionResult Index()
        {
            return View(db.Football.ToList());
        }

        // GET: Footballs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Football football = db.Football.Find(id);
            if (football == null)
            {
                return HttpNotFound();
            }
            return View(football);
        }

        // GET: Footballs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Footballs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchID,TeamName1,TeamName2,Status,WinningTeam,Points")] Football football)
        {
            if (ModelState.IsValid)
            {
                db.Football.Add(football);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(football);
        }

        // GET: Footballs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Football football = db.Football.Find(id);
            if (football == null)
            {
                return HttpNotFound();
            }
            return View(football);
        }

        // POST: Footballs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchID,TeamName1,TeamName2,Status,WinningTeam,Points")] Football football)
        {
            if (ModelState.IsValid)
            {
                db.Entry(football).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(football);
        }

        // GET: Footballs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Football football = db.Football.Find(id);
            if (football == null)
            {
                return HttpNotFound();
            }
            return View(football);
        }

        // POST: Footballs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Football football = db.Football.Find(id);
            db.Football.Remove(football);
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