using NeoFilm.Backend.Data;
using NeoFilm.Shared;
using System.Diagnostics.Metrics;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckSnacksAsync();
            await CheckPaymentsAsync();

        }

        private async Task CheckSnacksAsync()
        {
            if (!_context.Snacks.Any())
            {
                _context.Snacks.Add(new Snacks { Name = "Combo #1", UnitValue= 25000, Description = "1 Hamburguesa, 1 gaseosa", State = true, imageUrl= "HTTP" });
                _context.Snacks.Add(new Snacks { Name = "Combo #2", UnitValue = 60000, Description = "2 perros, 1 gaseosa, 1 crispetas medianas", State = false, imageUrl="image/http" });
                _context.Snacks.Add(new Snacks { Name = "Combo #3", UnitValue = 20000, Description = "crispetas, 1 gaseosa", State = false, imageUrl="http2/hg/" });

            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckPaymentsAsync()
        {
            if (!_context.Payments.Any())
            {
                _context.Payments.Add(new Payments { Name = "Visa" });
                _context.Payments.Add(new Payments { Name = "nequi" });
         

            }

            await _context.SaveChangesAsync();
        }




    }
}
