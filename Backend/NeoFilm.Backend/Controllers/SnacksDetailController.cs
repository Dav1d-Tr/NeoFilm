using Microsoft.AspNetCore.Mvc;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Dtos;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SnacksDetailController : GenericController<SnacksDetail>
    {
        private readonly IGenericUnitOfWork<SnacksDetail> _unitOfWork;
        private readonly ISnacksDetailUnitOfWork _detailUnitOfWork;

        public SnacksDetailController(IGenericUnitOfWork<SnacksDetail> unitOfWork, ISnacksDetailUnitOfWork DetailUnitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _detailUnitOfWork = DetailUnitOfWork;
        }

        [HttpGet]
        override public async Task<IActionResult> GetAsync()
        {
            var action = await _detailUnitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        override public async Task<IActionResult> GetAsync(int id)
        {
            var action = await _detailUnitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }
        [HttpPost("CreateWithDto")]
        public async Task<IActionResult> PostAsync(SnacksDetailDTO dto)
        {
            var action = await _detailUnitOfWork.AddAsync(dto);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }

    }
}
