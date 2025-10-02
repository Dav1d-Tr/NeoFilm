using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.Respositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Implementations
{
    public class VenuesUnitOfWork : GenericUnitOfWork<Venue>, IVenuesUnitOfWork
    {
        private readonly IVenuesRepository _venuesRepository;

        public VenuesUnitOfWork(IGenericRepository<Venue> repository, IVenuesRepository venuesRepository)
            : base(repository)
        {
            _venuesRepository = venuesRepository;
        }

        public override async Task<ActionResponse<IEnumerable<Venue>>> GetAsync() => await _venuesRepository.GetAsync();

        public override async Task<ActionResponse<Venue>> GetAsync(int id) => await _venuesRepository.GetAsync(id);
    }
}