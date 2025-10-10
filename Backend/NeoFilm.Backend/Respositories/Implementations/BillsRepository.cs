using Microsoft.EntityFrameworkCore;
using NeoFilm.Backend.Data;
using NeoFilm.Backend.Repositories.Implementations;
using NeoFilm.Backend.Respositories.Interfaces;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.Respositories.Implementations
{
    public class BillsRepository : GenericRepository<Bill>, IBillsRepository
    {
        private readonly DataContext _context;

        public BillsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<Bill>>> GetAsync()
        {var bills = await _context.Bill
                .Include(b => b.User)
                .Include(b => b.Payment)
                .Include(b => b.snacksDetails)
                    .ThenInclude(sd => sd.Snack)
                .Include(b => b.Tickets)
                    
                .ToListAsync();



            return new ActionResponse<IEnumerable<Bill>>
            {
                WasSuccess = true,
                Result = bills
            };
        }

        public override async Task<ActionResponse<Bill>> GetAsync(int id)
        {
            var bill = await _context.Bill
                .Include(b => b.User)
                .Include(b => b.Payment)
                .Include(b => b.snacksDetails)
                    .ThenInclude(sd => sd.Snack)
                .Include(b => b.Tickets)
    .FirstOrDefaultAsync(b => b.Id == id);

            if (bill == null)
            {
                return new ActionResponse<Bill>
                {

                Message = "Factura no encontrada"
                };
            }
            else
            {
                return new ActionResponse<Bill>
                {
                    WasSuccess = true,
                    Result = bill
                };
            }
        }

        public async Task<ActionResponse<Bill>> UpdateTotalAsync(int billId)
        {
            var bill = await _context.Bill
                .Include(b => b.snacksDetails)
                .Include(b => b.Tickets)
                .FirstOrDefaultAsync(b => b.Id == billId);

            if (bill == null)
            {
                return new ActionResponse<Bill>
                {
                    WasSuccess = false,
                    Message = "Factura no encontrada."
                };
            }

            var snacksTotal = bill.snacksDetails?.Sum(sd => sd.subtotal) ?? 0m;
            var ticketsTotal = bill.Tickets?.Sum(t => t.Price) ?? 0m;

            bill.Total = snacksTotal + ticketsTotal;

            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<Bill>
                {
                    WasSuccess = true,
                    Result = bill
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse<Bill>
                {
                    WasSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
