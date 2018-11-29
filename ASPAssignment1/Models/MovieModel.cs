namespace ASPAssignment1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MovieModel : DbContext
    {
        public MovieModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Movy> movies { get; set; }
        public virtual DbSet<Show> shows { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movy>()
                .Property(e => e.Movie_title)
                .IsFixedLength();

            modelBuilder.Entity<Movy>()
                .Property(e => e.Movie_genre)
                .IsFixedLength();

            modelBuilder.Entity<Movy>()
                .HasMany(e => e.shows)
                .WithRequired(e => e.movy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Show>()
                .Property(e => e.Show_theatre)
                .IsFixedLength();

            modelBuilder.Entity<Show>()
                .Property(e => e.Show_rating)
                .IsFixedLength();
        }
    }
}
