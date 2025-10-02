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
            await CheckCategoriesFilmsAsync();
            await CheckSnacksAsync();
            await CheckPaymentsAsync();
            await CheckRolesAsync();
            await CheckDocumentTypesAsync();
            await CheckUsersAsync();
            await CheckBillsAsync();
            await CheckFilmsAsync();
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
                _context.Snacks.Add(new Snacks { Name = "Combo Pareja", UnitValue = 25000, Description = "2 bebidas + 1 crispetas grandes.", State = true, imageUrl = "https://cdn.inoutdelivery.com/cinecolombia.inoutdelivery.com/sm/1709247175548-3.-Combo-Pareja.png", CategorieSnacksId = 2 });
                _context.Snacks.Add(new Snacks { Name = "Combo Familiar", UnitValue = 40000, Description = "4 bebidas + 2 crispetas grandes + 1 chocolatina.", State = false, imageUrl = "https://archivos-cms.cinecolombia.com/images/6/6/4/7/7466-9-esl-CO/6ce5ad738478-2532cine-colombia.jpg", CategorieSnacksId = 2 });
                _context.Snacks.Add(new Snacks { Name = "Combo Individual", UnitValue = 20000, Description = "1 bebida + 1 crispetas medianas.", State = false, imageUrl = "https://cdn.inoutdelivery.com/cinecolombia.inoutdelivery.com/sm/1709246679772-4.-Combo-Individual-Full.png", CategorieSnacksId = 2 });
                _context.Snacks.Add(new Snacks { Name = "Coca-Cola 600ml", UnitValue = 6000, Description = "Refresco clásico para acompañar tus comidas.", State = false, imageUrl = "https://product-images.farmatodo.com/GrH6Pk5kGpQqqxFt0fO3zcsC_bXyI7IX6cw-oic4oRTohGQrsx4BLrk_KdIHvFkrMQMGvxgcv3cVCatARJZQrzUj20NutlkH_2Sb2wav2kdDWMo=s350-rw", CategorieSnacksId = 1 });
                _context.Snacks.Add(new Snacks { Name = "Agua Cristal 500ml", UnitValue = 3000, Description = "Agua natural sin gas.", State = false, imageUrl = "https://coopasan.com.co/rails/active_storage/representations/proxy/eyJfcmFpbHMiOnsiZGF0YSI6MTUxMzY4NCwicHVyIjoiYmxvYl9pZCJ9fQ==--ee6f0a9e4ce292b68c8dc4b9e2812d3dbd547be6/eyJfcmFpbHMiOnsiZGF0YSI6eyJmb3JtYXQiOiJwbmciLCJyZXNpemVfdG9fZml0IjpbODAwLDgwMF19LCJwdXIiOiJ2YXJpYXRpb24ifX0=--cef66509c9cdc75663c0eefd9421db1d2ea4fead/ME00047.png?locale=es", CategorieSnacksId = 1 });
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

        private async Task CheckCategoriesFilmsAsync()
        {
            if (!_context.CategorieFilms.Any())
            {
                _context.CategorieFilms.Add(new CategorieFilms { Name = "Acción" });
                _context.CategorieFilms.Add(new CategorieFilms { Name = "Comedia" });
                _context.CategorieFilms.Add(new CategorieFilms { Name = "Drama" });
                _context.CategorieFilms.Add(new CategorieFilms { Name = "Ciencia Ficción" });
                _context.CategorieFilms.Add(new CategorieFilms { Name = "Terror" });
                _context.CategorieFilms.Add(new CategorieFilms { Name = "Animación" });
                _context.CategorieFilms.Add(new CategorieFilms { Name = "Documental" });
                _context.CategorieFilms.Add(new CategorieFilms { Name = "Romance" });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckFilmsAsync()
        {
            if (!_context.Films.Any())
            {
                _context.Films.Add(new Film
                {
                    Name = "El Viaje de los Sueños",
                    Description = "Un joven descubre un mundo mágico mientras busca a su hermano perdido.",
                    Duration = 125,
                    Distribution = "PG-13", // Uso clasificación en Distribution
                    ImageUrl = "https://image.tmdb.org/t/p/w500/2lECpi35Hnbpa4y46JX0aY3AWTy.jpg",
                    Trailer = "https://youtu.be/dummy1", // ⚡Pon un link válido si tienes
                    CategorieFilmsId = 1
                });

                _context.Films.Add(new Film
                {
                    Name = "Cyber Rescate",
                    Description = "Un equipo de hackers debe salvar la ciudad de un virus que controla la tecnología.",
                    Duration = 110,
                    Distribution = "PG-13",
                    ImageUrl = "https://image.tmdb.org/t/p/w500/r7vmZjiyZw9rpJMQJdXpjgiCOk9.jpg",
                    Trailer = "https://youtu.be/dummy2",
                    CategorieFilmsId = 1
                });

                _context.Films.Add(new Film
                {
                    Name = "Amor entre Sombras",
                    Description = "Dos almas gemelas se encuentran en circunstancias imposibles y luchan por su amor.",
                    Duration = 98,
                    Distribution = "PG",
                    ImageUrl = "https://pics.filmaffinity.com/Amor_entre_sombras-895239833-large.jpg",
                    Trailer = "https://youtu.be/dummy3",
                    CategorieFilmsId = 2
                });

                _context.Films.Add(new Film
                {
                    Name = "Buscando Justicia",
                    Description = "Un exsoldado busca justicia mientras enfrenta una red criminal internacional.",
                    Duration = 132,
                    Distribution = "R",
                    ImageUrl = "https://m.media-amazon.com/images/S/pv-target-images/61cd751fa24ae50aa6fc1d4670aab4eb437c5360de539138ab941c120f4025dd.jpg",
                    Trailer = "https://youtu.be/dummy4",
                    CategorieFilmsId = 3
                });
            }

            await _context.SaveChangesAsync();
        }



    }
}
