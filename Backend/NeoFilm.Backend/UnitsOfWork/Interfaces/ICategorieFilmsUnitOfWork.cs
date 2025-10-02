using NeoFilm.Shared.Responses;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.UnitsOfWork.Interfaces;

public interface ICategorieFilmsUnitOfWork
{
    Task<ActionResponse<CategorieFilms>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<CategorieFilms>>> GetAsync();
}