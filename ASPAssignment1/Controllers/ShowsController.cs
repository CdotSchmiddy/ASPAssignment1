using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPAssignment1.Models;

namespace ASPAssignment1.Controllers
{
    public class ShowsController : Controller
    {
        private MovieModel db = new MovieModel();

        // GET: Shows
        public ActionResult Index()
        {
            var shows = db.shows.Include(s => s.movy);
            return View(shows.ToList());
        }

        // GET: Shows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            show show = db.shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // GET: Shows/Create
        public ActionResult Create()
        {
            ViewBag.movie_id = new SelectList(db.movies, "movie_id", "movie_title");
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "show_id,show_theatre,show_time,show_rating,movie_id")] show show)
        {
            if (ModelState.IsValid)
            {
                db.shows.Add(show);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.movie_id = new SelectList(db.movies, "movie_id", "movie_title", show.movie_id);
            return View(show);
        }

        // GET: Shows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            show show = db.shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            ViewBag.movie_id = new SelectList(db.movies, "movie_id", "movie_title", show.movie_id);
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "show_id,show_theatre,show_time,show_rating,movie_id")] show show)
        {
            if (ModelState.IsValid)
            {
                db.Entry(show).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.movie_id = new SelectList(db.movies, "movie_id", "movie_title", show.movie_id);
            return View(show);
        }

        // GET: Shows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            show show = db.shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            show show = db.shows.Find(id);
            db.shows.Remove(show);
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
