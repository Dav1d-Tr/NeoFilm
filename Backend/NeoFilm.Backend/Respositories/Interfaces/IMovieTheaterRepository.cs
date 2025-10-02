using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.Respositories.Interfaces
{
    public interface IMovieTheaterRepository
    {
        Task<ActionResponse<MovieTheater>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<MovieTheater>>> GetAsync();
    }
}