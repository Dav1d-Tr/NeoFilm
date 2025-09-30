using Microsoft.EntityFrameworkCore;
using NeoFilm.Backend.Data;
using NeoFilm.Backend.Repositories.Implementations;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.Respositories.Implementations;
using NeoFilm.Backend.Respositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Implementations;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=LocalConnection"));
builder.Services.AddTransient<SeedDb>();

builder.Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IRolesUnitOfWork, RolesUnitOfWork>();
builder.Services.AddScoped<IBillsRepository, BillsRepository>();
builder.Services.AddScoped<IBillsUnitOfWork, BillsUnitOfWork>();

builder.Services.AddScoped<IDocumentsTypesRepository, DocumentsTypesRepository>();
builder.Services.AddScoped<IDocumentsTypesUnitOfWork, DocumentsTypesUnitOfWork>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // URL del frontend con Vite
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();
SeedData(app);

app.UseCors("AllowFrontend");

void SeedData(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory!.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeedDb>();
        service!.SeedAsync().Wait();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
