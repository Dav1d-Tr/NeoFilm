using NeoFilm.Shared.Responses;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.UnitsOfWork.Interfaces;

public interface IRolesUnitOfWork
{
    Task<ActionResponse<Role>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Role>>> GetAsync();
}