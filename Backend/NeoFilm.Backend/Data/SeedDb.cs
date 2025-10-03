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
            await CheckCategoriesFilmsAsync();
            await CheckVenuesAsync();
            await CheckMovieTheaterAsync();
            await CheckFormatsAsync();
            await CheckFilmsAsync();
            await CheckSeatsAsync();
            await CheckCategoriesSnacksAsync();
            await CheckRolesAsync();
            await CheckDocumentTypesAsync();
            await CheckSnacksAsync();
            await CheckUsersAsync();
            await CheckPaymentsAsync();
            await CheckBillsAsync();
            await CheckFunctionsAsync();
            await CheckTicketsAsync();
            await CheckSnacksDetailAsync();
        }

        private async Task CheckFunctionsAsync()
        {
            if (!_context.Functions.Any())
            {
                _context.Functions.Add(new Function
                {
                    Name = "Función 2D - Matiné",
                    Description = "Proyección en formato 2D en la primera tanda del día.",
                    Fecha = new DateTime(2025, 10, 5),
                    Hora = new TimeSpan(12, 0, 0),
                    FilmId = 1,        
                    FormatId = 1,      
                    MovieTheaterId = 1 
                });

                _context.Functions.Add(new Function
                {
                    Name = "Función 3D - Tarde",
                    Description = "Proyección en formato 3D con gafas.",
                    Fecha = new DateTime(2025, 10, 5),
                    Hora = new TimeSpan(16, 30, 0),
                    FilmId = 2,
                    FormatId = 2,
                    MovieTheaterId = 1
                });

                _context.Functions.Add(new Function
                {
                    Name = "Función IMAX - Noche",
                    Description = "Proyección en sala IMAX con mayor resolución y pantalla gigante.",
                    Fecha = new DateTime(2025, 10, 5),
                    Hora = new TimeSpan(20, 0, 0),
                    FilmId = 3,
                    FormatId = 3,
                    MovieTheaterId = 2
                });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckFormatsAsync()
        {
            if (!_context.Formats.Any())
            {
                _context.Formats.Add(new Format
                {
                    Name = "2D",
                    Description = "Formato tradicional en dos dimensiones."
                });

                _context.Formats.Add(new Format
                {
                    Name = "3D",
                    Description = "Formato tridimensional con gafas especiales."
                });

                _context.Formats.Add(new Format
                {
                    Name = "IMAX",
                    Description = "Pantalla de gran formato con mayor resolución."
                });

                _context.Formats.Add(new Format
                {
                    Name = "4DX",
                    Description = "Formato con efectos sensoriales (movimiento, agua, viento)."
                });
            }

            await _context.SaveChangesAsync();
        }


        private async Task CheckSeatsAsync()
        {
            if (!_context.Seats.Any())
            {
                _context.Seats.Add(new Seat
                {
                    Row = "A",
                    Number = 1,
                    Status = SeatStatus.Available,
                    MovieTheaterId = 1
                });

                _context.Seats.Add(new Seat
                {
                    Row = "A",
                    Number = 2,
                    Status = SeatStatus.Available,
                    MovieTheaterId = 1
                });
            }
            await _context.SaveChangesAsync();
        }

        private async Task CheckMovieTheaterAsync()
        {
            if (!_context.MovieTheaters.Any())
            {
                _context.MovieTheaters.Add(new MovieTheater
                {
                    Name = "Sala 1",
                    VenueId = 1,
                    Capacity = 15
                });
                _context.MovieTheaters.Add(new MovieTheater
                {
                    Name = "Sala VIP",
                    VenueId = 1,
                    Capacity = 40
                });

                _context.MovieTheaters.Add(new MovieTheater
                {
                    Name = "Sala IMAX",
                    VenueId = 2,
                    Capacity = 120
                });
            }
            await _context.SaveChangesAsync();
        }

        private async Task CheckVenuesAsync()
        {
            if (!_context.Venues.Any())
            {
                _context.Venues.Add(new Venue { Name = "Medayork", Location = "Centro comercial oviedo" });
                _context.Venues.Add(new Venue { Name = "Medallo", Location = "Centro comercial Aventura" });
            }
            await _context.SaveChangesAsync();
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
                var Bill = new Bill
                {
                    Date = DateTime.Now,
                    
                    UserId = 1,
                    PaymentId = 1
                };

                _context.Bill.Add(Bill);
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckUsersAsync()
        {
            if (!_context.Users.Any())
            {
                _context.Users.Add(new User
                {
                    Id = "1045864864",
                    Name = "Juan",
                    LastName = "Pérez",
                    Email = "neofilm88@gmail.com",
                    ValidateEmail = "neofilm88@gmail.com",
                    Password = "Secure123!",
                    ValidatePassword = "Secure123!",
                    PhoneNumber = "3001234567",
                    DocumentTypeId = 1,
                    RoleId = 1
                });

                _context.Users.Add(new User
                {
                    Id = "1025645873",
                    Name = "David",
                    LastName = "Rozo",
                    Email = "ddavid.rozod@gmail.com",
                    ValidateEmail = "ddavid.rozod@gmail.com",
                    Password = "Da1025645873*",
                    ValidatePassword = "Da1025645873*",
                    PhoneNumber = "3045599449",
                    DocumentTypeId = 1,
                    RoleId = 2
                });
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
                    Name = "TELEFONO NEGRO 2",
                    Description = "Hace cuatro años, Finn, de 13 años, mató a su secuestrador y escapó, convirtiéndose en el único sobreviviente de El Raptor. Pero el verdadero mal trasciende la muerte… y el teléfono vuelve a sonar.",
                    Duration = 114,
                    Distribution = "Ethan Hawke, Mason Thames, Madeleine McGraw, Demián Bichir, Miguel Mora, Jeremy Davies, Arianna Rivas",
                    ImageUrl = "https://www.pantallasprocinal.com.co/img/peliculas/1794.jpg?v=1.0.28",
                    Trailer = "https://youtu.be/7pdHPo4_8Pg?si=Ocs3ijtjKLVjocDB",
                    CategorieFilmsId = 1
                });

                _context.Films.Add(new Film
                {
                    Name = "JURASSIC WORLD REBIRTH",
                    Description = "Cinco años después de los acontecimientos de Jurassic World: Dominio, la ecología del planeta se ha vuelto inhóspita para los dinosaurios. Los que quedan viven en entornos ecuatoriales aislados con climas semejantes al de los lugares donde alguna vez prosperaron. Las tres criaturas más colosales de la tierra, el mar y el aire dentro de esa biosfera tropical poseen, en su ADN, la clave para un medicamento que aportará a la humanidad milagrosos beneficios para salvar vidas.",
                    Duration = 135,
                    Distribution = "Scarlett Johansson Mahershala Ali Jonathan Bailey Rupert Friend Manuel García-Rulfo Luna Blaise David Iacono Audrina Miranda Philippine Velge Bechir Sylvain Ed Skrein",
                    ImageUrl = "https://www.pantallasprocinal.com.co/img/peliculas/1664.jpg?v=1.0.28",
                    Trailer = "https://youtu.be/DzMbe-SKwxU?si=WNFhA4v631PBKrad",
                    CategorieFilmsId = 1
                });

                _context.Films.Add(new Film
                {
                    Name = "CAMINA O MUERE",
                    Description = "De la esperada adaptación de la primera novela escrita por el maestro narrador Stephen King,y Francis Lawrence, el director visionario de las películas de la franquicia Los Juegos del Hambre (En llamas, Sinsajo – Partes 1 y 2, y La balada de los pájaros cantores y las serpientes), llega The Long Walk/ Camina o Muere, un thriller intenso, escalofriante y emotivo que desafía al público a enfrentar una pregunta inquietante: ¿Hasta dónde serías capaz de llegar?",
                    Duration = 110,
                    Distribution = "Cooper Hoffman, David Jonsson, Garrett Wareing, Tut Nyuot, Charlie Plummer, Ben Wang, Roman Griffin Davis, Jordan Gonzalez, Josh Hamilton, Judy Greer, Mark Hamill",
                    ImageUrl = "https://www.pantallasprocinal.com.co/img/peliculas/1808.jpg?v=1.0.28",
                    Trailer = "https://youtu.be/acwv1gQgd0Y?si=fWTIIDWH-MM9XpDm",
                    CategorieFilmsId = 1
                });

                _context.Films.Add(new Film
                {
                    Name = "ZOOTOPIA 2",
                    Description = "Tras resolver el caso más importante en la historia de Zootopia, los oficiales novatos Judy Hopps y Nick Wilde descubren que su sociedad no es tan sólida como pensaban, cuando el Jefe Bogo les ordena unirse al programa de consejería “Compañeros en Crisis”. Sin embargo, su vínculo será puesto a prueba cuando se ven envueltos en una intrincada investigación relacionada con la llegada de una serpiente venenosa a la metrópoli de animales.",
                    Duration = 132,
                    Distribution = "Ginnifer Goodwin | Jason Bateman | Quinta Brunson | Idris Elba | Shakira",
                    ImageUrl = "https://www.pantallasprocinal.com.co/img/peliculas/1892.jpg?v=1.0.28",
                    Trailer = "https://youtu.be/7gytUpiues8?si=pzh-Iqdn2QLBc9C6",
                    CategorieFilmsId = 1
                });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckTicketsAsync()
        {
            if (!_context.Tickets.Any())
            {
                _context.Tickets.Add(new Ticket { BillId=1, FunctionId=1, SeatId=1, Price=20000, Description="pelicula" });
                
            }

            await _context.SaveChangesAsync();
        }
        private async Task CheckSnacksDetailAsync()
        {
            if (!_context.SnacksDetails.Any())
            {
                _context.SnacksDetails.Add(new SnacksDetail { BillId = 1, SnackId=1, Quantity=2, subtotal=1000});

            }

            await _context.SaveChangesAsync();
        }
    }
}