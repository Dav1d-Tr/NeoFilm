using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeoFilm.Backend.Data;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Implementations;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieTheaterController : GenericController<MovieTheater>
    {
        private readonly IMovieTheaterUnitOfWork _movieTheaterUnitOfWork;

        public MovieTheaterController(IGenericUnitOfWork<MovieTheater> unitOfWork, IMovieTheaterUnitOfWork movieTheaterUnitOfWork) : base(unitOfWork)
        {
            _movieTheaterUnitOfWork = movieTheaterUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
            var action = await _movieTheaterUnitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _movieTheaterUnitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }
    }
}