using Microsoft.AspNetCore.Mvc;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController : GenericController<Film>
    {
        private readonly IFilmsUnitOfWork _filmsUnitOfWork;
        public FilmController(IGenericUnitOfWork<Film> unitOfWork, IFilmsUnitOfWork filmsUnitOfWork) : base(unitOfWork)
        {
            _filmsUnitOfWork = filmsUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
        var action = await _filmsUnitOfWork.GetAsync();
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
        var action = await _filmsUnitOfWork.GetAsync(id);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
            return NotFound();
        }
    }
}
