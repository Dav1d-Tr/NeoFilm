using NeoFilm.Backend.Data;
using NeoFilm.Shared.Entities;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace NeoFilm.Backend.Repositories.Implementations;

public class CategorieSnacksRepository : GenericRepository<CategorieSnacks>, ICategorieSnacksRepository
{
    private readonly DataContext _context;
    public CategorieSnacksRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async override Task<ActionResponse<IEnumerable<CategorieSnacks>>> GetAsync()
    {
        var categoriesSnacks = await _context.CategorieSnacks
            .Include(r => r.Snacks)
            .ToListAsync();
        return new ActionResponse<IEnumerable<CategorieSnacks>>
        {
            WasSuccess = true,
            Result = categoriesSnacks
        };
    }

    public async override Task<ActionResponse<CategorieSnacks>> GetAsync(int id)
    {
        var categorieSnacks = await _context.CategorieSnacks
            .Include(r => r.Snacks)
            .FirstOrDefaultAsync(r => r.Id == id);
        if (categorieSnacks == null)
        {
            return new ActionResponse<CategorieSnacks>
            {
                Message = "Registro no encontrado"
            };
        }
        return new ActionResponse<CategorieSnacks>
        {
            WasSuccess = true,
            Result = categorieSnacks
        };        
    }
}