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
            await CheckRolesAsync();
            await CheckDocumentTypesAsync();
        }

        private async Task CheckDocumentTypesAsync()
        {
            if (!_context.DocumentTypes.Any())
            {
                _context.DocumentTypes.Add(new DocumentType { Name = "Cédula de Ciudadanía" });
                _context.DocumentTypes.Add(new DocumentType { Name = "Tarjeta de Identidad" });
                _context.DocumentTypes.Add(new DocumentType { Name = "Cédula de Extranjería" });
                _context.DocumentTypes.Add(new DocumentType { Name = "Pasaporte" });
            }
            await _context.SaveChangesAsync();
        }

        private async Task CheckRolesAsync()
        {
            if (!_context.Roles.Any())
            {
                _context.Roles.Add(new Role { Name = "Cliente" });
                _context.Roles.Add(new Role { Name = "Administrador" });
                _context.Roles.Add(new Role { Name = "Empleado" });
            }

            await _context.SaveChangesAsync();
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
