using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Implementations;

public class FormatsUnitOfWork : GenericUnitOfWork<Format>, IFormatsUnitOfWork
{
    private readonly IFormatsRepository _formatsRepository;

    public FormatsUnitOfWork(IGenericRepository<Format> repository, IFormatsRepository formatsRepository) : base(repository)
    {
        _formatsRepository = formatsRepository;
    }

    public override async Task<ActionResponse<IEnumerable<Format>>> GetAsync() => await _formatsRepository.GetAsync();

    public override async Task<ActionResponse<Format>> GetAsync(int id) => await _formatsRepository.GetAsync(id);
}