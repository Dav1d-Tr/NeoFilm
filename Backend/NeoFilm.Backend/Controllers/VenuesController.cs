using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeoFilm.Backend.Data;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VenuesController : GenericController<Venue>
{
    private readonly IVenuesUnitOfWork _venuesUnitOfWork;

    public VenuesController(IGenericUnitOfWork<Venue> unitOfWork, IVenuesUnitOfWork venuesUnitOfWork) : base(unitOfWork)
    {
        _venuesUnitOfWork = venuesUnitOfWork;
    }

    [HttpGet]
    public override async Task<IActionResult> GetAsync()
    {
        var action = await _venuesUnitOfWork.GetAsync();
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest();
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var action = await _venuesUnitOfWork.GetAsync(id);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return NotFound();
    }
}