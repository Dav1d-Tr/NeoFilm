using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.Respositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Implementations
{
    public class MovieTheaterUnitOfWork : GenericUnitOfWork<MovieTheater>, IMovieTheaterUnitOfWork
    {
        private readonly IMovieTheaterRepository _movieTheater;

        public MovieTheaterUnitOfWork(IGenericRepository<MovieTheater> repository, IMovieTheaterRepository movieTheaterRepository) : base(repository)
        {
            _movieTheater = movieTheaterRepository;
        }

        public override async Task<ActionResponse<IEnumerable<MovieTheater>>> GetAsync() => await _movieTheater.GetAsync();

        public override async Task<ActionResponse<MovieTheater>> GetAsync(int id) => await _movieTheater.GetAsync(id);
    }
}