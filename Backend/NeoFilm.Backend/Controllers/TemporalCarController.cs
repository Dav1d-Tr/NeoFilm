using Microsoft.AspNetCore.Mvc;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Dtos;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemporalCarController : ControllerBase
       
    {
        private readonly ITemporalCarUnitOfWork _unitOfWork;

        public TemporalCarController(ITemporalCarUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public virtual async Task<IActionResult> GetAsync()
        {
            var action = await _unitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartAsync(int id, [FromBody] TemporalCar model)
        {
            if (id != model.Id)
                return BadRequest("El ID del carrito no coincide con el modelo enviado.");

            var result = await _unitOfWork.UpdateAsync(model);

            if (result.WasSuccess)
                return Ok(result.Result);

            return BadRequest(result.Message);
        }


        [HttpPost("crear orden")]
        public async Task<IActionResult> CreateBillAsync(int carritoId, int paymentId)
        {
            var result = await _unitOfWork.CreateBillAsync(carritoId, paymentId);
            if (result.WasSuccess)
            {
                return Ok(result.Result);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("{carritoId}/clear")]
        public async Task<IActionResult> ClearCartAsync(int carritoId)
        {
            var result = await _unitOfWork.ClearCarAsync(carritoId);

            if (result.WasSuccess)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        [HttpPost("{carritoId}/add-snack")]
        public async Task<IActionResult> AddSnackAsync(int carritoId, [FromBody] SnacksDetailDTO snack)
        {
            var action = await _unitOfWork.AddSnacksAsync(carritoId, snack);

            if (action.WasSuccess)
                return Ok(action.Result);

            return BadRequest(action.Message);
        }

        [HttpPost("{carritoId}/add-ticket")]
        public async Task<IActionResult> AddTicketAsync(int carritoId, [FromBody] TicketDTO ticket)
        {
            var action = await _unitOfWork.AddTicketsAsync(carritoId, ticket);

            if (action.WasSuccess)
                return Ok(action.Result);

            return BadRequest(action.Message);
        }
    }
}
