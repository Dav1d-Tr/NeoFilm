using NeoFilm.Shared.Responses;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.UnitsOfWork.Interfaces;

public interface IFilmsUnitOfWork
{
    Task<ActionResponse<Film>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Film>>> GetAsync();
}