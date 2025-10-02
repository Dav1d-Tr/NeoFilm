using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Implementations;

public class CategorieFilmsUnitOfWork : GenericUnitOfWork<CategorieFilms>, ICategorieFilmsUnitOfWork
{
    private readonly ICategorieFilmsRepository _categoriesFilmsRepository;

    public CategorieFilmsUnitOfWork(IGenericRepository<CategorieFilms> repository, ICategorieFilmsRepository categoriesFilmsRepository) : base(repository)
    {
        _categoriesFilmsRepository = categoriesFilmsRepository;
    }

    public override async Task<ActionResponse<IEnumerable<CategorieFilms>>> GetAsync() => await _categoriesFilmsRepository.GetAsync();

    public override async Task<ActionResponse<CategorieFilms>> GetAsync(int id) => await _categoriesFilmsRepository.GetAsync(id);
}