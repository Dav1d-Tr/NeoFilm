using NeoFilm.Shared.Responses;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Repositories.Interfaces;

public interface IDocumentsTypesRepository
{
    Task<ActionResponse<DocumentType>> GetAsync(int id);
    
    Task<ActionResponse<IEnumerable<DocumentType>>> GetAsync();
}