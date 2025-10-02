using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Implementations;

public class FilmsUnitOfWork : GenericUnitOfWork<Film>, IFilmsUnitOfWork
{
    private readonly IFilmsRepository _filmsRepository;

    public FilmsUnitOfWork(IGenericRepository<Film> repository, IFilmsRepository filmsRepository) : base(repository)
    {
        _filmsRepository = filmsRepository;
    }

    public override async Task<ActionResponse<IEnumerable<Film>>> GetAsync() => await _filmsRepository.GetAsync();

    override public async Task<ActionResponse<Film>> GetAsync(int id) => await _filmsRepository.GetAsync(id);
}