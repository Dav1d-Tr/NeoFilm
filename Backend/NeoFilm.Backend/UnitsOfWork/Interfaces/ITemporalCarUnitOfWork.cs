using Microsoft.AspNetCore.Mvc;
using NeoFilm.Shared.Dtos;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Interfaces
{
    public interface ITemporalCarUnitOfWork
    {
        Task<ActionResponse<IEnumerable<TemporalCar>>> GetAsync();

        Task<ActionResponse<TemporalCar>> AddAsync(TemporalCar entity);

        Task<ActionResponse<bool>> ClearCarAsync(int id);

        Task<ActionResponse<TemporalCar>> UpdateAsync(TemporalCar entity);
        Task<ActionResponse<Bill>> CreateBillAsync(int carritoId, int paymentId);
        Task<ActionResponse<TemporalCar>> AddSnacksAsync(int carritoId, [FromBody] SnacksDetailDTO snack);
        Task<ActionResponse<TemporalCar>> AddTicketsAsync(int carritoId, [FromBody] TicketDTO ticket);
    }
}
