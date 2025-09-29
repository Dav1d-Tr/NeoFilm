using NeoFilm.Backend.Data;
using NeoFilm.Shared.Entities;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace NeoFilm.Backend.Repositories.Implementations;

public class RolesRepository : GenericRepository<Role>, IRolesRepository
{
    private readonly DataContext _context;
    public RolesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async override Task<ActionResponse<IEnumerable<Role>>> GetAsync()
    {
        var roles = await _context.Roles
            .Include(r => r.Users)
            .ToListAsync();
        return new ActionResponse<IEnumerable<Role>>
        {
            WasSuccess = true,
            Result = roles
        };
    }

    public async override Task<ActionResponse<Role>> GetAsync(int id)
    {
        var role = await _context.Roles
            .Include(r => r.Users)
            .FirstOrDefaultAsync(r => r.Id == id);
        if (role == null)
        {
            return new ActionResponse<Role>
            {
                Message = "Registro no encontrado"
            };
        }
        return new ActionResponse<Role>
        {
            WasSuccess = true,
            Result = role
        };        
    }
}