using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.Respositories.Interfaces
{
    public interface IVenuesRepository
    {
        Task<ActionResponse<Venue>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Venue>>> GetAsync();
    }
}