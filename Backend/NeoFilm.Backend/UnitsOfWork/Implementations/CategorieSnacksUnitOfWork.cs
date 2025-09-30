using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Implementations;

public class CategorieSnacksUnitOfWork : GenericUnitOfWork<CategorieSnacks>, ICategorieSnacksUnitOfWork
{
    private readonly ICategorieSnacksRepository _categoriesSnacksRepository;

    public CategorieSnacksUnitOfWork(IGenericRepository<CategorieSnacks> repository, ICategorieSnacksRepository categoriesSnacksRepository) : base(repository)
    {
        _categoriesSnacksRepository = categoriesSnacksRepository;
    }

    public override async Task<ActionResponse<IEnumerable<CategorieSnacks>>> GetAsync() => await _categoriesSnacksRepository.GetAsync();

    public override async Task<ActionResponse<CategorieSnacks>> GetAsync(int id) => await _categoriesSnacksRepository.GetAsync(id);
}