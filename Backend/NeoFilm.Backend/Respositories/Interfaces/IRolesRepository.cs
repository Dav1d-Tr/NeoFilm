using NeoFilm.Shared.Responses;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Repositories.Interfaces;

public interface IRolesRepository
{
    Task<ActionResponse<Role>> GetAsync(int id);
    
    Task<ActionResponse<IEnumerable<Role>>> GetAsync();
}