using Microsoft.AspNetCore.Mvc;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController : GenericController<Film>
    {
        private readonly IGenericUnitOfWork<Film> _unitOfWork;

        public FilmController(IGenericUnitOfWork<Film> unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
        [HttpPost]
        public override async Task<IActionResult> PostAsync([FromBody] Film film)
        {
            
            
            var result = await _unitOfWork.AddAsync(film);

            if (!result.WasSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok("Usuario agregado correctamente");
        }
    }
}
