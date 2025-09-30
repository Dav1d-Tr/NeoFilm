using NeoFilm.Shared.Responses;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Repositories.Interfaces;

public interface ICategorieSnacksRepository
{
    Task<ActionResponse<CategorieSnacks>> GetAsync(int id);
    
    Task<ActionResponse<IEnumerable<CategorieSnacks>>> GetAsync();
}