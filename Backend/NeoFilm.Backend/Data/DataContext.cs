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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Payments>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Snacks>().HasIndex(c => c.Name).IsUnique();
        }
    }

}
