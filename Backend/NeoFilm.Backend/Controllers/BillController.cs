using Microsoft.AspNetCore.Mvc;
using NeoFilm.Backend.Controllers;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;


namespace NeoFilm.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillController : GenericController<Bill>
    {
        private readonly IBillsUnitOfWork _billsunitofwork;

        public BillController(IGenericUnitOfWork<Bill> unit, IBillsUnitOfWork billsunitofwork) : base(unit)
        {
            _billsunitofwork = billsunitofwork;
        }

        [HttpGet]
        override public async Task<IActionResult> GetAsync()
        {
            var action = await _billsunitofwork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        override public async Task<IActionResult> GetAsync(int id)
        {
            var action = await _billsunitofwork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }
    }
}
