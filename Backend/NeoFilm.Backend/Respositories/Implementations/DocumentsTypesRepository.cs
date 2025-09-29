using NeoFilm.Backend.Data;
using NeoFilm.Shared.Entities;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace NeoFilm.Backend.Repositories.Implementations;

public class DocumentsTypesRepository : GenericRepository<DocumentType>, IDocumentsTypesRepository
{
    private readonly DataContext _context;
    public DocumentsTypesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async override Task<ActionResponse<IEnumerable<DocumentType>>> GetAsync()
    {
        var documentTypes = await _context.DocumentTypes
            .Include(p => p.Users)
            .ToListAsync();
        return new ActionResponse<IEnumerable<DocumentType>>
        {
            WasSuccess = true,
            Result = documentTypes
        };
    }

    public async override Task<ActionResponse<DocumentType>> GetAsync(int id)
    {
        var documenType = await _context.DocumentTypes
            .Include(p => p.Users)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (documenType == null)
        {
            return new ActionResponse<DocumentType>
            {
                Message = "Registro no encontrado"
            };
        }
        return new ActionResponse<DocumentType>
        {
            WasSuccess = true,
            Result = documenType
        };        
    }
}