using NeoFilm.Backend.Data;
using NeoFilm.Shared.Entities;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace NeoFilm.Backend.Repositories.Implementations;

public class FormatsRepository : GenericRepository<Format>, IFormatsRepository
{
    private readonly DataContext _context;
    public FormatsRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async override Task<ActionResponse<IEnumerable<Format>>> GetAsync()
    {
        var formats = await _context.Formats
            .Include(r => r.Functions)
            .ToListAsync();
        return new ActionResponse<IEnumerable<Format>>
        {
            WasSuccess = true,
            Result = formats
        };
    }

    public async override Task<ActionResponse<Format>> GetAsync(int id)
    {
        var format = await _context.Formats
            .Include(r => r.Functions)
            .FirstOrDefaultAsync(r => r.Id == id);
        if (format == null)
        {
            return new ActionResponse<Format>
            {
                Message = "Registro no encontrado"
            };
        }
        return new ActionResponse<Format>
        {
            WasSuccess = true,
            Result = format
        };        
    }
}