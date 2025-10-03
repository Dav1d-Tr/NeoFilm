using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.Respositories.Interfaces
{
    public interface ITicketsRepository
    {
        Task<ActionResponse<Ticket>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Ticket>>> GetAsync();
    }
}
