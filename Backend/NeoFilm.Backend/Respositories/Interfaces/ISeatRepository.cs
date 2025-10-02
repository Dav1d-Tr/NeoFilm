using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.Respositories.Interfaces
{
    public interface ISeatRepository
    {
        Task<ActionResponse<Seat>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Seat>>> GetAsync();
    }
}