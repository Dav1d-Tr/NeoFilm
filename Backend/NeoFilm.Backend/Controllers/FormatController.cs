using Microsoft.AspNetCore.Mvc;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormatController : GenericController<Format>
    {
        private readonly IFormatsUnitOfWork _formatsUnitOfWork;
        public FormatController(IGenericUnitOfWork<Format> unitOfWork, IFormatsUnitOfWork formatsUnitOfWork) : base(unitOfWork)
        {
            _formatsUnitOfWork = formatsUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
        var action = await _formatsUnitOfWork.GetAsync();
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
        var action = await _formatsUnitOfWork.GetAsync(id);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
            return NotFound();
        }
    }
}
