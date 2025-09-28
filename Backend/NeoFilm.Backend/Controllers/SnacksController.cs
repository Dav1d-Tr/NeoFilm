using Microsoft.AspNetCore.Mvc;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Shared.Entities;


namespace NeoFilm.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SnacksController : GenericController<Snacks>
    {
        private readonly IGenericUnitOfWork<Snacks> _unitOfWork;

        public SnacksController(IGenericUnitOfWork<Snacks> unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public override async Task<IActionResult> PostAsync([FromBody] Snacks snack)
        {
            
            var factory = new SnackFactory(snack.Name, snack.UnitValue, snack.Description, snack.State, snack.imageUrl);
            var snackCreado = (Snacks)factory.CrearProducto();

            var result = await _unitOfWork.AddAsync(snackCreado);

            if (!result.WasSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok("Snack agregado correctamente");
        }
    }
}