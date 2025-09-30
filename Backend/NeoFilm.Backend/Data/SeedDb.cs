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
            await CheckCategoriesSnacksAsync();
            await CheckSnacksAsync();
            await CheckPaymentsAsync();
            await CheckRolesAsync();
            await CheckDocumentTypesAsync();
            await CheckUsersAsync();
            await CheckBillsAsync();    
        }

        private async Task CheckCategoriesSnacksAsync()
        {
            if (!_context.CategorieSnacks.Any())
            {
                _context.CategorieSnacks.Add(new CategorieSnacks { Name = "Bebidas" });
                _context.CategorieSnacks.Add(new CategorieSnacks { Name = "Combos" });
                _context.CategorieSnacks.Add(new CategorieSnacks { Name = "Dulceria" });
            }
            await _context.SaveChangesAsync();
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
                _context.Snacks.Add(new Snacks { Name = "Combo Pareja", UnitValue= 25000, Description = "2 bebidas + 1 crispetas grandes.", State = true, imageUrl= "https://cdn.inoutdelivery.com/cinecolombia.inoutdelivery.com/sm/1709247175548-3.-Combo-Pareja.png", CategorieSnacksId = 2 });
                _context.Snacks.Add(new Snacks { Name = "Combo Familiar", UnitValue = 40000, Description = "4 bebidas + 2 crispetas grandes + 1 chocolatina.", State = false, imageUrl="https://archivos-cms.cinecolombia.com/images/6/6/4/7/7466-9-esl-CO/6ce5ad738478-2532cine-colombia.jpg", CategorieSnacksId = 2 });
                _context.Snacks.Add(new Snacks { Name = "Combo Individual", UnitValue = 20000, Description = "1 bebida + 1 crispetas medianas.", State = false, imageUrl="https://cdn.inoutdelivery.com/cinecolombia.inoutdelivery.com/sm/1709246679772-4.-Combo-Individual-Full.png", CategorieSnacksId = 2 });
                _context.Snacks.Add(new Snacks { Name = "Coca-Cola 600ml", UnitValue = 6000, Description = "Refresco clásico para acompañar tus comidas.", State = false, imageUrl="https://product-images.farmatodo.com/GrH6Pk5kGpQqqxFt0fO3zcsC_bXyI7IX6cw-oic4oRTohGQrsx4BLrk_KdIHvFkrMQMGvxgcv3cVCatARJZQrzUj20NutlkH_2Sb2wav2kdDWMo=s350-rw", CategorieSnacksId = 1 });
                _context.Snacks.Add(new Snacks { Name = "Agua Cristal 500ml", UnitValue = 3000, Description = "Agua natural sin gas.", State = false, imageUrl="https://coopasan.com.co/rails/active_storage/representations/proxy/eyJfcmFpbHMiOnsiZGF0YSI6MTUxMzY4NCwicHVyIjoiYmxvYl9pZCJ9fQ==--ee6f0a9e4ce292b68c8dc4b9e2812d3dbd547be6/eyJfcmFpbHMiOnsiZGF0YSI6eyJmb3JtYXQiOiJwbmciLCJyZXNpemVfdG9fZml0IjpbODAwLDgwMF19LCJwdXIiOiJ2YXJpYXRpb24ifX0=--cef66509c9cdc75663c0eefd9421db1d2ea4fead/ME00047.png?locale=es", CategorieSnacksId = 1 });
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
                    Id = "1", 
                    Name = "Juan",
                    LastName = "Pérez",
                    Email = "neofilm88@gmail.com",
                    ValidateEmail = "neofilm88@gmail.com",
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
