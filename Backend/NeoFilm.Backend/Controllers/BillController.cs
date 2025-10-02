using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeoFilm.Backend.Data;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Implementations;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Entities;
using QRCoder;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;



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
                string qrData = $"FACTURA_{savedBill.Id}";
                string qrUrl = $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={Uri.EscapeDataString(qrData)}";

                var emailBody = $@"
    <html>
        <body style='font-family: Arial, sans-serif; color: #333;'>
            <h2 style='color: #4CAF50;'>Factura Registrada</h2>
            <p>Hola <strong>{user.Name}</strong>,</p>
            <p>Tu orden <strong>#{savedBill.Id}</strong> fue registrada exitosamente.</p>
<p>
  <strong>
    Resumen:<br />
método de pago: {savedBill.Payment.Name} <br />
    Total: {savedBill.Total}
  </strong>
</p>
            
<p>Cuando vayas a una de nuestras sedes muestra el siguiente correo para recibir tus prodctos</p>
<img src='{qrUrl}' alt='Código QR' style='margin: 20px 0;'/>
            <p>Gracias por confiar en nosotros.</p>
<p>Neofilm-Colombia.</p>

            <hr />
            <p style='font-size: 0.9em; color: #777;'>Este es un correo automático, por favor no respondas.</p>
        </body>
    </html>";

                await _emailService.SendEmailAsync(
                    user.Email,
                    "Factura registrada",
                    emailBody
                );
            }

            return Ok(savedBill);
        }


    }
}
