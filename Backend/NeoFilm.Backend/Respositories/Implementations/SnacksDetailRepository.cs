using Microsoft.EntityFrameworkCore;
using NeoFilm.Backend.Data;
using NeoFilm.Backend.Repositories.Implementations;
using NeoFilm.Backend.Respositories.Interfaces;
using NeoFilm.Shared.Dtos;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.Respositories.Implementations
{
    public class SnacksDetailRepository : GenericRepository<SnacksDetail>, ISnacksDetailRespositoy
    {
        private readonly DataContext _context;
        private readonly IBillsRepository _repository;

        public SnacksDetailRepository(DataContext context, IBillsRepository repository) : base(context)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<ActionResponse<SnacksDetail>> AddAsync(SnacksDetailDTO dto)
        {
            var snack = await _context.Snacks.FindAsync(dto.SnackId);
            if (snack == null)
            {
                return new ActionResponse<SnacksDetail>
                {
                    WasSuccess = false,
                    Message = "Snack no encontrado."
                };
            }
            var bill = await _context.Bill.FindAsync(dto.BillId);
            if (bill == null)
            {
                return new ActionResponse<SnacksDetail>
                {
                    WasSuccess = false,
                    Message = "Factura no encontrada."
                };

            }
            var detail = new SnacksDetail
            {
                SnackId = dto.SnackId,
                BillId = dto.BillId,
                Quantity = dto.Quantity,
                subtotal = dto.Quantity * snack.UnitValue
            };
            _context.SnacksDetails.Add(detail);
            



            try
            {
                await _context.SaveChangesAsync();
                await _repository.UpdateTotalAsync(dto.BillId);
                return new ActionResponse<SnacksDetail>
                {
                    WasSuccess = true,
                    Result = detail
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse<SnacksDetail>
                {
                    Message = ex.Message
                };
            }
        }

        public override async Task<ActionResponse<IEnumerable<SnacksDetail>>> GetAsync()
        {
            var SnacksDetails = await _context.SnacksDetails
                .Include(b => b.Snack)
                .Include(b => b.Bill)
                .ToListAsync();
            foreach (var detail in SnacksDetails)
            {
                detail.subtotal = detail.Quantity * detail.Snack.UnitValue;
            }
            return new ActionResponse<IEnumerable<SnacksDetail>>
            {
                WasSuccess = true,
                Result = SnacksDetails
            };
        }

        public override async Task<ActionResponse<SnacksDetail>> GetAsync(int id)
        {
            var SnacksDetail = await _context.SnacksDetails
                .Include(b => b.Snack)
                .Include(b => b.Bill)
                .FirstOrDefaultAsync(b => b.Id == id);




            if (SnacksDetail == null)
            {
                return new ActionResponse<SnacksDetail>
                {

                    Message = "SnacksDetail no encontrado"
                };
            }
            else
            {
                return new ActionResponse<SnacksDetail>
                {
                    WasSuccess = true,
                    Result = SnacksDetail
                };
            }
        }
        }
}
