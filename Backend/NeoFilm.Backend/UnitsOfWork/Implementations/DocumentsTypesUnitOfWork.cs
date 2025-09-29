using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Implementations;

public class DocumentsTypesUnitOfWork : GenericUnitOfWork<DocumentType>, IDocumentsTypesUnitOfWork
{
    private readonly IDocumentsTypesRepository _documentsTypesRepository;

    public DocumentsTypesUnitOfWork(IGenericRepository<DocumentType> repository, IDocumentsTypesRepository documentsTypesRepository) : base(repository)
    {
        _documentsTypesRepository = documentsTypesRepository;
    }

    public override async Task<ActionResponse<IEnumerable<DocumentType>>> GetAsync() => await _documentsTypesRepository.GetAsync();

    override public async Task<ActionResponse<DocumentType>> GetAsync(int id) => await _documentsTypesRepository.GetAsync(id);
}