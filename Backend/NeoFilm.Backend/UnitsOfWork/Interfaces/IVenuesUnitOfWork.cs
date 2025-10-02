using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Interfaces
{
    public interface IVenuesUnitOfWork
    {
        Task<ActionResponse<Venue>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Venue>>> GetAsync();
    }
}