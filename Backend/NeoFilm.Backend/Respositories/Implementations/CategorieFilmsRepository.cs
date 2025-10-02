using NeoFilm.Backend.Data;
using NeoFilm.Shared.Entities;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace NeoFilm.Backend.Repositories.Implementations;

public class CategorieFilmsRepository : GenericRepository<CategorieFilms>, ICategorieFilmsRepository
{
    private readonly DataContext _context;
    public CategorieFilmsRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async override Task<ActionResponse<IEnumerable<CategorieFilms>>> GetAsync()
    {
        var categorieFilms = await _context.CategorieFilms
            .Include(r => r.Films)
            .ToListAsync();
        return new ActionResponse<IEnumerable<CategorieFilms>>
        {
            WasSuccess = true,
            Result = categorieFilms
        };
    }

    public async override Task<ActionResponse<CategorieFilms>> GetAsync(int id)
    {
        var categorieFilm = await _context.CategorieFilms
            .Include(r => r.Films)
            .FirstOrDefaultAsync(r => r.Id == id);
        if (categorieFilm == null)
        {
            return new ActionResponse<CategorieFilms>
            {
                Message = "Registro no encontrado"
            };
        }
        return new ActionResponse<CategorieFilms>
        {
            WasSuccess = true,
            Result = categorieFilm
        };        
    }
}