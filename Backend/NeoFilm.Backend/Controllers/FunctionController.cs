using Microsoft.AspNetCore.Mvc;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FunctionController : GenericController<Function>
    {
        private readonly IGenericUnitOfWork<Function> _unitOfWork;

        public FunctionController(IGenericUnitOfWork<Function> unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
        [HttpPost]
        public override async Task<IActionResult> PostAsync([FromBody] Function function)
        {
            var result = await _unitOfWork.AddAsync(function);

            if (!result.WasSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok("Usuario agregado correctamente");
        }
    }
}
