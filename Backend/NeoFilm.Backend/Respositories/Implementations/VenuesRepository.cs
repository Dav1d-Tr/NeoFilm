using Microsoft.EntityFrameworkCore;
using NeoFilm.Backend.Data;
using NeoFilm.Backend.Repositories.Implementations;
using NeoFilm.Backend.Respositories.Interfaces;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.Respositories.Implementations
{
    public class VenuesRepository : GenericRepository<Venue>, IVenuesRepository
    {
        private readonly DataContext _context;

        public VenuesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<Venue>>> GetAsync()
        {
            var venues = await _context.Venues
                .Include(x => x.MovieTheaters).ToListAsync();
            return new ActionResponse<IEnumerable<Venue>>
            {
                WasSuccess = true,
                Result = venues,
            };
        }

        public override async Task<ActionResponse<Venue>> GetAsync(int id)
        {
            var venues = await _context.Venues
                .Include(x => x.MovieTheaters)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (venues == null)
            {
                return new ActionResponse<Venue>
                {
                    Message = "Sede no encontrada"
                };
            }
            return new ActionResponse<Venue>
            {
                WasSuccess = true,
                Result = venues,
            };
        }
    }
}