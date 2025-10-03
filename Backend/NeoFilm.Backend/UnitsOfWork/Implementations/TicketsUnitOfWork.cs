using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.Respositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Implementations
{
    public class TicketsUnitOfWork : GenericUnitOfWork<Ticket>, ITicketsUnitOfWork
    {
        private readonly IGenericRepository<Ticket> _repository;
        private readonly ITicketsRepository _ticketsRepository;

        public TicketsUnitOfWork(IGenericRepository<Ticket> repository, ITicketsRepository ticketsRepository) : base(repository)
        {
            _repository = repository;
            _ticketsRepository = ticketsRepository;
        }
        public override async Task<ActionResponse<IEnumerable<Ticket>>> GetAsync() => await _ticketsRepository.GetAsync();
        public override async Task<ActionResponse<Ticket>> GetAsync(int id) => await _ticketsRepository.GetAsync(id);


    }
}
