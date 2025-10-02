using NeoFilm.Shared.Responses;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Repositories.Interfaces;

public interface IFilmsRepository
{
    Task<ActionResponse<Film>> GetAsync(int id);
    
    Task<ActionResponse<IEnumerable<Film>>> GetAsync();
}