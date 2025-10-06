using Microsoft.EntityFrameworkCore;
using NeoFilm.Backend.Data;
using NeoFilm.Backend.Repositories.Implementations;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.Respositories.Interfaces;
using NeoFilm.Shared.Dtos;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.Respositories.Implementations;

public class TicketsRepository : GenericRepository<Ticket>, ITicketsRepository
{
    private readonly DataContext _context;
    private readonly IBillsRepository _repository;
    private readonly DbSet<Ticket> _entity;

    public TicketsRepository(DataContext context, IBillsRepository repository) : base(context)
    {
        _context = context;
        _repository = repository;
        _entity = context.Set<Ticket>();
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

    public virtual async Task<ActionResponse<Ticket>> AddAsync(TicketDTO dto)
       
    {
        var bill = await _context.Bill.FindAsync(dto.BillId);
        if(bill== null)
        {
            return new ActionResponse<Ticket>
            {
                WasSuccess = false,
                Message = "Factura no encontrada."
            };
        }
        var seat = await _context.Seats.FindAsync(dto.SeatId);
        if (seat == null)
        {
            return new ActionResponse<Ticket>
            {
                WasSuccess = false,
                Message = "Asiento no encontrado."
            };
        }

        var detail = new Ticket
        {
            Price = dto.Price,
            BillId = dto.BillId,
            Description = dto.Description,
            FunctionId = dto.FunctionId,
            SeatId = dto.SeatId

        };
        _context.Tickets.Add(detail);
        try
        {
            await _repository.UpdateTotalAsync(dto.BillId);

            await _context.SaveChangesAsync();
            return new ActionResponse<Ticket>
            {
                WasSuccess = true,
                Result = detail
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception exception)
        {
            return ExceptionActionResponse(exception);
        }
    }

    public override async Task<ActionResponse<Ticket>> DeleteAsync(int id)
    {
        var row = await _entity.FindAsync(id);
        if (row == null)
        {
            return new ActionResponse<Ticket>
            {
                WasSuccess = false,
                Message = "Registro no encontrado"
            };
        }

        try
        {
            _entity.Remove(row);
            await _repository.UpdateTotalAsync(row.BillId);
            await _context.SaveChangesAsync();
            return new ActionResponse<Ticket>
            {
                WasSuccess = true,
            };
        }
        catch
        {
            return new ActionResponse<Ticket>
            {
                WasSuccess = false,
                Message = "No se puede borrar, porque tiene registros relacionados"
            };
        }
    }
    private ActionResponse<Ticket> ExceptionActionResponse(Exception exception)
    {
        return new ActionResponse<Ticket>
        {
            WasSuccess = false,
            Message = exception.Message
        };
    }

    private ActionResponse<Ticket> DbUpdateExceptionActionResponse()
    {
        return new ActionResponse<Ticket>
        {
            WasSuccess = false,
            Message = "Ya existe el registro que estas intentando crear."
        };
    }

}
