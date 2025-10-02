using Microsoft.AspNetCore.Mvc;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatController : GenericController<Seat>
    {
        public SeatController(IGenericUnitOfWork<Seat> unitOfWork) : base(unitOfWork)
        {
        }
    }
}