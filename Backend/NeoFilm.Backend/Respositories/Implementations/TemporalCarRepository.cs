using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeoFilm.Backend.Data;
using NeoFilm.Backend.Repositories.Interfaces;
using NeoFilm.Backend.Respositories.Interfaces;
using NeoFilm.Shared.Dtos;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;
using System.Linq;
using System.Linq.Expressions;

namespace NeoFilm.Backend.Respositories.Implementations
{
    public class TemporalCarRepository : ITemporalCarRepository
    {
        private readonly DataContext _context;
        private readonly IGenericRepository<Ticket> _generic;
        private readonly IGenericRepository<SnacksDetail> _snacks;
        private readonly EmailService _emailService;
        private readonly DbSet<TemporalCar> _entity;

        public TemporalCarRepository(DataContext context, IGenericRepository<Ticket> generic, IGenericRepository<SnacksDetail> snacks, EmailService emailService)
        {
            _context = context;
            _generic = generic;
            _snacks = snacks;
            _emailService = emailService;
            _entity = context.Set<TemporalCar>();
        }
        public virtual async Task<ActionResponse<TemporalCar>> AddAsync(TemporalCar entity)
        {
            _context.Add(entity);
            try
            {
                await RecalcularTotalAsync(entity.Id);
                await _context.SaveChangesAsync();
                return new ActionResponse<TemporalCar>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception exception)
            {
                return ExceptionActionResponse(exception);
            }
        }
        public async Task<ActionResponse<Bill>> CreateBillAsync(int carritoId, int paymentId)
        {
            var carrito = await _context.TemporalCars
                .Include(c => c.Ticket)
                .Include(c => c.SnacksDetail)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == carritoId);

            if (carrito == null)
            {
                return new ActionResponse<Bill> { WasSuccess = false, Message = "Carrito vacío o no encontrado" };
            }

            var factura = new Bill
            {
                UserId = carrito.UserId,
                Total = carrito.Total,
                Date = DateTime.UtcNow,
                PaymentId = paymentId
            };
            _context.Bill.Add(factura);
            await _context.SaveChangesAsync();
            foreach (var snack in carrito.SnacksDetail)
            {
                snack.BillId = factura.Id;
                _context.SnacksDetails.Update(snack);
            }

            foreach (var ticket in carrito.Ticket)
            {
                ticket.BillId = factura.Id;
                _context.Tickets.Update(ticket);
            }
            await _context.SaveChangesAsync();
            var facturaCompleta = await _context.Bill
       .Include(b => b.snacksDetails).ThenInclude(sd => sd.Snack)
       .Include(b => b.Tickets).ThenInclude(t => t.Seat)
       .Include(b => b.Payment)
       .Include(b => b.User)
       .FirstOrDefaultAsync(b => b.Id == factura.Id);
            if (facturaCompleta?.User != null)
            {
                await SendBillEmailAsync(facturaCompleta, facturaCompleta.User);
            }



            await ClearCarAsync(carritoId);



            await _context.SaveChangesAsync();

            return new ActionResponse<Bill> { WasSuccess = true, Result = factura };
        }


        public async Task<ActionResponse<bool>> ClearCarAsync(int carritoId)
        {
            try
            {
                var carrito = await _context.TemporalCars
                    .Include(c => c.Ticket)
                    .Include(c => c.SnacksDetail)
                    .FirstOrDefaultAsync(c => c.Id == carritoId);

                if (carrito == null)
                {
                    return new ActionResponse<bool>
                    {
                        WasSuccess = false,
                        Message = "Carrito no encontrado."
                    };
                }

                _context.Tickets.RemoveRange(carrito.Ticket);
                _context.SnacksDetails.RemoveRange(carrito.SnacksDetail);

                carrito.Total = 0; 

                await _context.SaveChangesAsync();

                return new ActionResponse<bool>
                {
                    WasSuccess = true,
                    Result = true,
                    Message = "Carrito vaciado correctamente."
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse<bool>
                {
                    WasSuccess = false,
                    Message = $"Error al vaciar el carrito: {ex.Message}"
                };
            }
        }

        public virtual async Task<ActionResponse<IEnumerable<TemporalCar>>> GetAsync()
        {
            return new ActionResponse<IEnumerable<TemporalCar>>
            {
                WasSuccess = true,
                Result = await _entity
                .Include(r => r.User)
                .Include(c => c.Ticket)
                .Include(c => c.SnacksDetail).ToListAsync()
            };
        }
        public async Task<ActionResponse<TemporalCar>> UpdateAsync(TemporalCar entity)
        {
            try
            {
                var carrito = await _context.TemporalCars
                    .Include(c => c.Ticket)
                    .Include(c => c.SnacksDetail)
                    .FirstOrDefaultAsync(c => c.Id == entity.Id);

                if (carrito == null)
                {
                    return new ActionResponse<TemporalCar>
                    {
                        WasSuccess = false,
                        Message = "Carrito no encontrado."
                    };
                }

              
                carrito.comments = entity.comments ?? carrito.comments;
                carrito.UserId = !string.IsNullOrEmpty(entity.UserId) ? entity.UserId : carrito.UserId;

                await _context.SaveChangesAsync();

                await RecalcularTotalAsync(carrito.Id);

                return new ActionResponse<TemporalCar>
                {
                    WasSuccess = true,
                    Result = carrito
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse<TemporalCar>
                {
                    WasSuccess = false,
                    Message = $"Error al actualizar carrito: {ex.Message}"
                };
            }
        }


        private ActionResponse<TemporalCar> ExceptionActionResponse(Exception exception)
        {
            return new ActionResponse<TemporalCar>
            {
                WasSuccess = false,
                Message = exception.Message
            };
        }

        private ActionResponse<TemporalCar> DbUpdateExceptionActionResponse()
        {
            return new ActionResponse<TemporalCar>
            {
                WasSuccess = false,
                Message = "Ya existe el registro que estas intentando crear."
            };
        }
        public async Task RecalcularTotalAsync(int carritoId)
        {
            var carrito = await _context.Set<TemporalCar>()
                .Include(c => c.Ticket)
                .Include(c => c.SnacksDetail)
                .ThenInclude(sd => sd.Snack)
                .FirstOrDefaultAsync(c => c.Id == carritoId);

            if (carrito != null)
            {
                carrito.Total = carrito.Ticket.Sum(t => t.Price) + carrito.SnacksDetail.Sum(c => c.subtotal);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ActionResponse<TemporalCar>> AddSnacksAsync(int carritoId, [FromBody] SnacksDetailDTO snack)
        {
            try
            {
              
                var carrito = await _context.TemporalCars
                    .Include(c => c.SnacksDetail)
                    
                    .Include(c => c.Ticket)
                    .FirstOrDefaultAsync(c => c.Id == carritoId);

                if (carrito == null)
                {
                    return new ActionResponse<TemporalCar>
                    {
                        WasSuccess = false,
                        Message = "Carrito no encontrado."
                    };
                }





                var snacks = await _context.Snacks.FindAsync(snack.SnackId);
                if (snack == null)
                {
                    return new ActionResponse<TemporalCar>
                    {
                        WasSuccess = false,
                        Message = "Snack no encontrado."
                    };
                }

                
                var detalle = new SnacksDetail
                {
                    SnackId = snack.SnackId,
                    Quantity = snack.Quantity,
                    subtotal = snack.Quantity * snacks.UnitValue
                };

              
                carrito.SnacksDetail.Add(detalle);


                await RecalcularTotalAsync(carritoId);

          
                var carritoActualizado = await _context.TemporalCars
                    .Include(c => c.SnacksDetail)
                    .Include(c => c.Ticket)
                    .FirstOrDefaultAsync(c => c.Id == carritoId);
                

                return new ActionResponse<TemporalCar>
                {
                    WasSuccess = true,
                    Result = carritoActualizado!
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse<TemporalCar>
                {
                    WasSuccess = false,
                    Message = $"Error al agregar snack: {ex.Message}"
                };
            }
        }

        public async Task<ActionResponse<TemporalCar>> AddTicketsAsync(int carritoId, [FromBody]TicketDTO ticket)
        {
            try
            {

                var carrito = await _context.TemporalCars
                    .Include(c => c.SnacksDetail)

                    .Include(c => c.Ticket)
                    .FirstOrDefaultAsync(c => c.Id == carritoId);

                if (carrito == null)
                {
                    return new ActionResponse<TemporalCar>
                    {
                        WasSuccess = false,
                        Message = "Carrito no encontrado."
                    };
                }




                var detalle = new Ticket
                {
                    Description = ticket.Description,
                    Price = ticket.Price,
                    FunctionId = ticket.FunctionId,
                    SeatId = ticket.SeatId,
                   
                };


                carrito.Ticket.Add(detalle);


                await RecalcularTotalAsync(carritoId);


                var carritoActualizado = await _context.TemporalCars
                    .Include(c => c.SnacksDetail)
                    .ThenInclude(sd => sd.Snack)
                    .Include(c => c.Ticket)
                    
                    .FirstOrDefaultAsync(c => c.Id == carritoId);
             

                

                return new ActionResponse<TemporalCar>
                {
                    WasSuccess = true,
                    Result = carritoActualizado!
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse<TemporalCar>
                {
                    WasSuccess = false,
                    Message = $"Error al agregar ticket: {ex.Message}"
                };
            }
        }

        private async Task SendBillEmailAsync(Bill factura, User user)
        {
            if (string.IsNullOrWhiteSpace(user.Email))
                return;
            

            string qrData = $"FACTURA_{factura.Id}";
            string qrUrl = $"https://api.qrserver.com/v1/create-qr-code/?size=150x150&data={Uri.EscapeDataString(qrData)}";
            string snacksHtml = string.Empty;
            string ticketsHtml = string.Empty;
            if (factura.snacksDetails != null && factura.snacksDetails.Any())
            {
                snacksHtml = "<h3>Snacks:</h3><ul>";
                foreach (var s in factura.snacksDetails)
                {
                    snacksHtml += $"<li>{s.Snack?.Name ?? "Snack desconocido"} — Cantidad: {s.Quantity} — Subtotal: {s.subtotal:C}</li>";
                }
                snacksHtml += "</ul>";
            }
            if (factura.Tickets != null && factura.Tickets.Any())
            {
                ticketsHtml = "<h3>Boletos:</h3><ul>";
                foreach (var t in factura.Tickets)
                {
                    ticketsHtml += $"<li>{t.Description ?? "Boleto"} — Asiento: {t.Seat?.Row}{t.Seat?.Number} — Precio: {t.Price:C}</li>";
                }
                ticketsHtml += "</ul>";
            }

            var emailBody = $@"
    <html>
        <body style='font-family: Arial, sans-serif; color: #333;'>
            <h2 style='color: #4CAF50;'>Factura Registrada</h2>
            <p>Hola <strong>{user.Name}</strong>,</p>
            <p>Tu orden fue registrada exitosamente.</p>
            <p>
                <strong>
                    Método de pago: {factura.Payment?.Name ?? "No especificado"} <br />
{snacksHtml}
            {ticketsHtml}
                    Total: {factura.Total:C}
                </strong>
            </p>
            <p>Cuando vayas a una de nuestras sedes muestra el siguiente QR para recibir tus productos:</p>
            <img src='{qrUrl}' alt='Código QR' style='margin: 20px 0;'/>
            <p>Gracias por confiar en nosotros.</p>
            <p>Neofilm - Colombia</p>
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

    }
    
}
