﻿using System;
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
        //disable auto database connection
        //private MovieModel db = new MovieModel();

        private IShowsMock db;

        // default constructor
        public ShowsController()
        {
            this.db = new EFShows();
        }

        // mock constructor
        public ShowsController(IShowsMock mock)
        {
            this.db = mock;
        }

        // GET: Shows
        public ActionResult Index()
        {
            var shows = db.shows.Include(s => s.movy);
            //return View(shows.ToList());
            return View("Index", shows.ToList());
        }

        // GET: Shows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            //show show = db.shows.Find(id);
            Show show = db.shows.SingleOrDefault(a => a.Show_id == id);

            if (show == null)
            {
                return View("Error");
            }
            return View("Details", show);
        }

        // GET: Shows/Create
        public ActionResult Create()
        {
            ViewBag.movie_id = new SelectList(db.movies, "movie_id", "movie_title");
            ViewBag.Show_rating = new SelectList(db.shows.OrderBy(g => g.Show_rating), "Show_rating", "Name");
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "show_id,show_theatre,show_time,show_rating,movie_id")] Show show)
        {
            if (ModelState.IsValid)
            {
                //db.shows.Add(show);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.movie_id = new SelectList(db.movies, "movie_id", "movie_title", "show.movie_id");
            ViewBag.Show_rating = new SelectList(db.shows.OrderBy(g => g.Show_rating), "Show_rating", "Name", show.Show_rating);
            return View(show);
        }

        // GET: Shows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            Show show = db.shows.SingleOrDefault(a => a.Show_id == id);
            if (show == null)
            {
                //return HttpNotFound();
                return View("Error");
            }
            ViewBag.movie_id = new SelectList(db.movies, "movie_id", "movie_title", "show.movie_id");
            ViewBag.Show_rating = new SelectList(db.shows.OrderBy(g => g.Show_rating), "Show_rating", "Name", show.Show_rating);
            return View("Edit", show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "show_id,show_theatre,show_time,show_rating,movie_id")] Show show)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(show).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.movie_id = new SelectList(db.movies, "movie_id", "movie_title", "show.movie_id");
            ViewBag.Show_rating = new SelectList(db.shows.OrderBy(g => g.Show_rating), "Show_rating", "Name", show.Show_rating);
            return View("Edit", show);
        }

        // GET: Shows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            //Show show = db.shows.Find(id);
            Show show = db.shows.SingleOrDefault(a => a.Show_id == id);

            if (show == null)
            {
                return View("Error");
            }
            return View("Delete", show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            //Show show = db.shows.Find(id);
            Show show = db.shows.SingleOrDefault(a => a.Show_id == id);

            //db.shows.Remove(show);
            //db.SaveChanges();
            db.Delete(show);

            if (id == null)
            {
                return View("Error");
            }

            if (show == null)
            {
                return View("Error");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
