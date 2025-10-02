using Microsoft.AspNetCore.Mvc;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategorieFilmsController : GenericController<CategorieFilms>
    {
        private readonly ICategorieFilmsUnitOfWork _categorieFilmsUnitOfWork;
        public CategorieFilmsController(IGenericUnitOfWork<CategorieFilms> unitOfWork, ICategorieFilmsUnitOfWork categorieFilmsUnitOfWork) : base(unitOfWork)
        {
            _categorieFilmsUnitOfWork = categorieFilmsUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
        var action = await _categorieFilmsUnitOfWork.GetAsync();
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
        var action = await _categorieFilmsUnitOfWork.GetAsync(id);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
            return NotFound();
        }
    }
}
