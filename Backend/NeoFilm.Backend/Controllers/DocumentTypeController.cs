using Microsoft.AspNetCore.Mvc;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;

namespace NeoFilm.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentTypeController : GenericController<DocumentType>
    {
        private readonly IDocumentsTypesUnitOfWork _documentsTypesUnitOfWork;
        public DocumentTypeController(IGenericUnitOfWork<DocumentType> unitOfWork, IDocumentsTypesUnitOfWork documentsTypesUnitOfWork) : base(unitOfWork)
        {
            _documentsTypesUnitOfWork = documentsTypesUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
            var action = await _documentsTypesUnitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _documentsTypesUnitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }
    }
}
