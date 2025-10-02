using NeoFilm.Shared.Responses;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.UnitsOfWork.Interfaces;

public interface IFormatsUnitOfWork
{
    Task<ActionResponse<Format>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Format>>> GetAsync();
}