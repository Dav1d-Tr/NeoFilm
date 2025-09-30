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
    }
}
