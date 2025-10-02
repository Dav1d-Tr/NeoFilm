using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Interfaces
{
    public interface IMovieTheaterUnitOfWork
    {
        Task<ActionResponse<MovieTheater>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<MovieTheater>>> GetAsync();
    }
}