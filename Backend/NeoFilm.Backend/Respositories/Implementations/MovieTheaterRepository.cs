using Microsoft.EntityFrameworkCore;
using NeoFilm.Backend.Data;
using NeoFilm.Backend.Repositories.Implementations;
using NeoFilm.Backend.Respositories.Interfaces;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.Respositories.Implementations
{
    public class MovieTheaterRepository : GenericRepository<MovieTheater>, IMovieTheaterRepository
    {
        private readonly DataContext _context;

        public MovieTheaterRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<MovieTheater>>> GetAsync()
        {
            var movie = await _context.MovieTheaters
                .Include(x => x.Seats).ToListAsync();
            return new ActionResponse<IEnumerable<MovieTheater>>
            {
                WasSuccess = true,
                Result = movie,
            };
        }

        public override async Task<ActionResponse<MovieTheater>> GetAsync(int id)
        {
            var movie = await _context.MovieTheaters
                .Include(x => x.Seats)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null)
            {
                return new ActionResponse<MovieTheater>
                {
                    Message = "Sala no encontrada"
                };
            }
            return new ActionResponse<MovieTheater>
            {
                WasSuccess = true,
                Result = movie,
            };
        }
    }
}