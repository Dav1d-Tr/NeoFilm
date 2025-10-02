using NeoFilm.Shared.Responses;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Repositories.Interfaces;

public interface IFormatsRepository
{
    Task<ActionResponse<Format>> GetAsync(int id);
    
    Task<ActionResponse<IEnumerable<Format>>> GetAsync();
}