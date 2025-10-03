using Microsoft.AspNetCore.Mvc;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;

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

        [HttpPost]
        public override async Task<IActionResult> PostAsync([FromBody] Ticket Ticket)
        {

            var factory = new TicketsFactory(Ticket.FunctionId, Ticket.BillId, Ticket.SeatId, Ticket.Price);
            var TicketCreado = (Ticket)factory.CrearProducto();

            var result = await _unitOfWork.AddAsync(TicketCreado);

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
    }
}
