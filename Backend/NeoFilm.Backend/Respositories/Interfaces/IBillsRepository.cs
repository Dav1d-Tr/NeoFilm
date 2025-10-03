using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.Respositories.Interfaces
{
    public interface IBillsRepository
    {

        Task<ActionResponse<Bill>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Bill>>> GetAsync();
        Task<ActionResponse<Bill>> UpdateTotalAsync(int billId);
    }
}
