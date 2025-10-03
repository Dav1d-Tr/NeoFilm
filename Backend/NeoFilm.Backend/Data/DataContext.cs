using Microsoft.EntityFrameworkCore;
using NeoFilm.Shared.Entities;
using System.Diagnostics.Metrics;

namespace NeoFilm.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Snacks> Snacks { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<CategorieSnacks> CategorieSnacks { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<CategorieFilms> CategorieFilms { get; set; }
        public DbSet<Format> Formats  { get; set; }
        public DbSet<Function> Functions  { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<MovieTheater> MovieTheaters { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<SnacksDetail> SnacksDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Payments>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Snacks>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Role>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<User>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(c => c.PhoneNumber).IsUnique();
            modelBuilder.Entity<DocumentType>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<CategorieSnacks>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<CategorieFilms>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Film>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Format>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Function>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Venue>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<MovieTheater>().HasIndex(x => new { x.Id, x.Name }).IsUnique();
            modelBuilder.Entity<Seat>().Property(c => c.Status).HasConversion<string>();
            DisableCascadeDelete(modelBuilder);
            modelBuilder.Entity<Ticket>()
    .HasIndex(t => new { t.FunctionId, t.SeatId })
    .IsUnique();
        }

        private void DisableCascadeDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}