using Microsoft.AspNetCore.Mvc;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : GenericController<User>
    {
        private readonly IGenericUnitOfWork<User> _unitOfWork;

        public UserController(IGenericUnitOfWork<User> unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
        [HttpPost]
        public override async Task<IActionResult> PostAsync([FromBody] User user)
        {
            
            
            var result = await _unitOfWork.AddAsync(user);

            if (!result.WasSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok("Usuario agregado correctamente");
        }
    }
}
