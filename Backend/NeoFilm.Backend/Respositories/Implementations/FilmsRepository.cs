using NeoFilm.Backend.Data;
using NeoFilm.Shared.Entities;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace NeoFilm.Backend.Repositories.Implementations;

public class FilmsRepository : GenericRepository<Film>, IFilmsRepository
{
    private readonly DataContext _context;
    public FilmsRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async override Task<ActionResponse<IEnumerable<Film>>> GetAsync()
    {
        var films = await _context.Films
            .Include(r => r.Functions)
            .ToListAsync();
        return new ActionResponse<IEnumerable<Film>>
        {
            WasSuccess = true,
            Result = films
        };
    }

    public async override Task<ActionResponse<Film>> GetAsync(int id)
    {
        var film = await _context.Films
            .Include(r => r.Functions)
            .FirstOrDefaultAsync(r => r.Id == id);
        if (film == null)
        {
            return new ActionResponse<Film>
            {
                Message = "Registro no encontrado"
            };
        }
        return new ActionResponse<Film>
        {
            WasSuccess = true,
            Result = film
        };        
    }
}