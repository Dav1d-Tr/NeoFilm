using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.Respositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Implementations
{
    public class BillsUnitOfWork : GenericUnitOfWork<Bill>, IBillsUnitOfWork
    {
        private readonly IGenericRepository<Bill> _repository;
        private readonly IBillsRepository _billsrepository;

        public BillsUnitOfWork(IGenericRepository<Bill> repository, IBillsRepository billsrepository) : base(repository)
        {
            _repository = repository;
            _billsrepository = billsrepository;
        }

        public override async Task<ActionResponse<IEnumerable<Bill>>> GetAsync() => await _billsrepository.GetAsync();   
        public override async Task<ActionResponse<Bill>> GetAsync(int id) => await _billsrepository.GetAsync(id);
    }
}
