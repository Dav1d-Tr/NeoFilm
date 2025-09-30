using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Interfaces
{
    public interface IBillsUnitOfWork
    {
        Task<ActionResponse<Bill>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Bill>>> GetAsync();
    }
}
