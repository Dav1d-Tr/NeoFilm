using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.Respositories.Implementations;
using NeoFilm.Backend.Respositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Dtos;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Implementations
{
    public class SnackDetailsUnitOfWork : GenericUnitOfWork<SnacksDetail>, ISnacksDetailUnitOfWork
    {
        private readonly IGenericRepository<SnacksDetail> _repository;
        private readonly ISnacksDetailRespositoy _snacksDetailRespository;

        public SnackDetailsUnitOfWork(IGenericRepository<SnacksDetail> repository, ISnacksDetailRespositoy SnacksDetailRespositoy) : base(repository)
        {
            _repository = repository;
            _snacksDetailRespository = SnacksDetailRespositoy;
        }

        public override async Task<ActionResponse<IEnumerable<SnacksDetail>>> GetAsync() => await _snacksDetailRespository.GetAsync();
        public override async Task<ActionResponse<SnacksDetail>> GetAsync(int id) => await _snacksDetailRespository.GetAsync(id);
        public virtual async Task<ActionResponse<SnacksDetail>> AddAsync(SnacksDetailDTO dto) => await _snacksDetailRespository.AddAsync(dto);
    }
}
