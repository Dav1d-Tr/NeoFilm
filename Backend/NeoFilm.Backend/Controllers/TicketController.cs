using Microsoft.AspNetCore.Mvc;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Dtos;
using NeoFilm.Shared.Entities;
using System.Net.Sockets;

namespace NeoFilm.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : GenericController<Ticket>
    {
        private readonly IGenericUnitOfWork<Ticket> _unitOfWork;
        private readonly ITicketsUnitOfWork _ticketsUnitOfWork;

        public TicketController(IGenericUnitOfWork<Ticket> unitOfWork, ITicketsUnitOfWork ticketsUnitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _ticketsUnitOfWork = ticketsUnitOfWork;
        }

        [HttpPost("DTO")]
        public async Task<IActionResult> PostAsync(TicketDTO dto)
        {

            var factory = new TicketsFactory(dto.FunctionId, dto.BillId,dto.SeatId, dto.Price, dto.Description);
            var TicketCreado = (Ticket)factory.CrearProducto();

            var ticketDtoResult = new TicketDTO
            {
                
                BillId = TicketCreado.BillId,
                FunctionId = TicketCreado.FunctionId,
                SeatId = TicketCreado.SeatId,
                Price = TicketCreado.Price,
                Description= TicketCreado.Description
            };

            var result = await _ticketsUnitOfWork.AddAsync(ticketDtoResult);

            if (!result.WasSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok("Ticket agregado correctamente");
        }


        [HttpGet]
        override public async Task<IActionResult> GetAsync()
        {
            var action = await _ticketsUnitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        override public async Task<IActionResult> GetAsync(int id)
        {
            var action = await _ticketsUnitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public override async Task<IActionResult> DeleteAsync(int id)
        {
            var action = await _ticketsUnitOfWork.DeleteAsync(id);
            if (action.WasSuccess)
            {
                return NoContent();
            }
            return BadRequest(action.Message);
        }

    }
}
