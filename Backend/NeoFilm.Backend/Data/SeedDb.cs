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
            await CheckUsersAsync();
            await CheckBillsAsync();    
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

        private async Task CheckBillsAsync()
        {
            if (!_context.Bill.Any())
            {
                var bill = new Bill
                {
                    Date = DateTime.Now,
                    Total = 100000,
                    UserId = 1, 
                    PaymentId = 1
                };

                _context.Bill.Add(bill);
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckUsersAsync()
        {
            if (!_context.Users.Any())
            {
                var user1 = new User
                {
                    Id = "1234567890", 
                    Name = "Juan",
                    LastName = "Pérez",
                    Email = "juan.perez@example.com",
                    ValidateEmail = "juan.perez@example.com",
                    Password = "Secure123!", 
                    ValidatePassword = "Secure123!",
                    PhoneNumber = "3001234567",
                    DocumentTypeId = 1, 
                    RoleId = 1          
                };

                _context.Users.Add(user1);
            }

            await _context.SaveChangesAsync();
        }




    }
}
