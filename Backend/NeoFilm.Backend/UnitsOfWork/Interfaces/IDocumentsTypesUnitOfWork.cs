using NeoFilm.Shared.Responses;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.UnitsOfWork.Interfaces;

public interface IDocumentsTypesUnitOfWork
{
    Task<ActionResponse<DocumentType>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<DocumentType>>> GetAsync();
}