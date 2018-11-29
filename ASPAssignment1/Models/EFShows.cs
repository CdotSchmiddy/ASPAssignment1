using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPAssignment1.Models
{
    public class EFShows : IShowsMock
    {
        //connect db
        private MovieModel db = new MovieModel();
        public IQueryable<Show> shows { get { return db.shows; } }
        public IQueryable<Movy> movies { get { return db.movies; } }

        public void Delete(Show Show)
        {
            db.shows.Remove(Show);
            db.SaveChanges();
        }

        public Show Saved(Show Show)
        {
            if (Show.Show_id == 0)
            {
                db.shows.Add(Show);
            }
            else
            {
                //update
                db.Entry(Show).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return Show;
        }
    }
}