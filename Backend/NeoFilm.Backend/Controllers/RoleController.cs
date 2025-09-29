using Microsoft.AspNetCore.Mvc;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : GenericController<Role>
    {
        private readonly IRolesUnitOfWork _rolesUnitOfWork;
        public RoleController(IGenericUnitOfWork<Role> unitOfWork, IRolesUnitOfWork rolesUnitOfWork) : base(unitOfWork)
        {
            _rolesUnitOfWork = rolesUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
        var action = await _rolesUnitOfWork.GetAsync();
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
        var action = await _rolesUnitOfWork.GetAsync(id);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
            return NotFound();
        }
    }
}
