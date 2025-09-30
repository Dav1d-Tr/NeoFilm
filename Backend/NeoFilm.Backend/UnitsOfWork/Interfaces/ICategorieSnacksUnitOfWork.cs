using NeoFilm.Shared.Responses;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.UnitsOfWork.Interfaces;

public interface ICategorieSnacksUnitOfWork
{
    Task<ActionResponse<CategorieSnacks>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<CategorieSnacks>>> GetAsync();
}