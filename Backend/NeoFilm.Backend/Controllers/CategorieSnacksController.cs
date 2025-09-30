using Microsoft.AspNetCore.Mvc;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategorieSnacksController : GenericController<CategorieSnacks>
    {
        private readonly ICategorieSnacksUnitOfWork _categoriesSnacksUnitOfWork;
        public CategorieSnacksController(IGenericUnitOfWork<CategorieSnacks> unitOfWork, ICategorieSnacksUnitOfWork categoriesSnacksUnitOfWork) : base(unitOfWork)
        {
            _categoriesSnacksUnitOfWork = categoriesSnacksUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
        var action = await _categoriesSnacksUnitOfWork.GetAsync();
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
        var action = await _categoriesSnacksUnitOfWork.GetAsync(id);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
            return NotFound();
        }
    }
}
