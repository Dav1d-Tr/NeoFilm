using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Interfaces
{
    public interface ISeatUnitOfWork
    {
        Task<ActionResponse<Seat>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Seat>>> GetAsync();
    }
}