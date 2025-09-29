using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Implementations;

public class RolesUnitOfWork : GenericUnitOfWork<Role>, IRolesUnitOfWork
{
    private readonly IRolesRepository _rolesRepository;

    public RolesUnitOfWork(IGenericRepository<Role> repository, IRolesRepository rolesRepository) : base(repository)
    {
        _rolesRepository = rolesRepository;
    }

    public override async Task<ActionResponse<IEnumerable<Role>>> GetAsync() => await _rolesRepository.GetAsync();

    override public async Task<ActionResponse<Role>> GetAsync(int id) => await _rolesRepository.GetAsync(id);
}