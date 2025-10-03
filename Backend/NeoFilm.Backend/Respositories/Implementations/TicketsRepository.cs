using Microsoft.EntityFrameworkCore;
using NeoFilm.Backend.Data;
using NeoFilm.Backend.Repositories.Implementations;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.Respositories.Interfaces;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.Respositories.Implementations;

public class TicketsRepository : GenericRepository<Ticket>, ITicketsRepository
{
    private readonly DataContext _context;

    public TicketsRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<IEnumerable<Ticket>>> GetAsync()
    {
        var Tickets = await _context.Tickets
            .Include(b => b.Function)
            .Include(b => b.Seat)
            .Include(b => b.Bill)
            .ToListAsync();
        return new ActionResponse<IEnumerable<Ticket>>
        {
            WasSuccess = true,
            Result = Tickets
        };
    }

    public override async Task<ActionResponse<Ticket>> GetAsync(int id)
    {
        var Ticket = await _context.Tickets
            .Include(b => b.Function)
            .Include(b => b.Seat)
            .Include(b => b.Bill)
            .FirstOrDefaultAsync(b => b.Id == id);



        if (Ticket == null)
        {
            return new ActionResponse<Ticket>
            {

                Message = "Ticket no encontrado"
            };
        }
        else
        {
            return new ActionResponse<Ticket>
            {
                WasSuccess = true,
                Result = Ticket
            };
        }
    }

}
