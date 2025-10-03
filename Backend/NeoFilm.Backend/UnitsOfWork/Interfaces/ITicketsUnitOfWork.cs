using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Interfaces
{
    public interface ITicketsUnitOfWork
    {
        Task<ActionResponse<Ticket>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Ticket>>> GetAsync();
    }
}
