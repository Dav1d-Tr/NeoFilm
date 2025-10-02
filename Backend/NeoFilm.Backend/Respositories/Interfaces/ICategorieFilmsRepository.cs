using NeoFilm.Shared.Responses;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Repositories.Interfaces;

public interface ICategorieFilmsRepository
{
    Task<ActionResponse<CategorieFilms>> GetAsync(int id);
    
    Task<ActionResponse<IEnumerable<CategorieFilms>>> GetAsync();
}