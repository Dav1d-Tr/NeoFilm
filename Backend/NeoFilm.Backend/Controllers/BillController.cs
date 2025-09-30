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
    public class BillController : GenericController<Bill>
    {
        private readonly IGenericUnitOfWork<Bill> _unit;
        private readonly IBillsUnitOfWork _billsUnitOfWork;
        private readonly EmailService _emailService;
        private readonly DataContext _context;  

        public BillController(
            IGenericUnitOfWork<Bill> unit,
            IBillsUnitOfWork billsUnitOfWork,
            EmailService emailService,
            DataContext context  
        ) : base(unit)
        {
            _unit = unit;
            _billsUnitOfWork = billsUnitOfWork;
            _emailService = emailService;
            _context = context; 
        }


        [HttpGet]
        override public async Task<IActionResult> GetAsync()
        {
            var action = await _billsUnitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        override public async Task<IActionResult> GetAsync(int id)
        {
            var action = await _billsUnitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateBillDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           
            var user = await _context.Users.FindAsync(model.UserId.ToString());
            if (user == null)
                return BadRequest("Usuario no encontrado.");

            var bill = new Bill
            {
                Date = model.Date,
                Total = model.Total,
                UserId = model.UserId,
                PaymentId = model.PaymentId
            };

            var action = await _unit.AddAsync(bill);
            if (!action.WasSuccess)
                return BadRequest(action.Message);

            var savedBill = action.Result;

           
            var reload = await _billsUnitOfWork.GetAsync(savedBill.Id);
            if (reload.WasSuccess)
                savedBill = reload.Result;

            
            if (!string.IsNullOrWhiteSpace(user.Email))
            {
                await _emailService.SendEmailAsync(
                    user.Email,
                    "Factura registrada",
                    $"Hola {user.Name}, tu factura #{savedBill.Id} fue registrada."
                );
            }

            return Ok(savedBill);
        }


    }
}
