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

        public virtual DbSet<movy> movies { get; set; }
        public virtual DbSet<show> shows { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<movy>()
                .Property(e => e.movie_title)
                .IsFixedLength();

            modelBuilder.Entity<movy>()
                .Property(e => e.movie_genre)
                .IsFixedLength();

            modelBuilder.Entity<movy>()
                .HasMany(e => e.shows)
                .WithRequired(e => e.movy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<show>()
                .Property(e => e.show_theatre)
                .IsFixedLength();

            modelBuilder.Entity<show>()
                .Property(e => e.show_rating)
                .IsFixedLength();
        }
    }
}
