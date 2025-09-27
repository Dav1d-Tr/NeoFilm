using Microsoft.AspNetCore.Mvc;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Controllers
{
   

        [ApiController]
        [Route("api/[controller]")]
        public class PaymentsController : GenericController<Payments>
        {
            public PaymentsController(IGenericUnitOfWork<Payments> unit) : base(unit)
            {
            }
        }
    
}
