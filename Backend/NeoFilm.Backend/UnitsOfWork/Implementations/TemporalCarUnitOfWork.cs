using Microsoft.AspNetCore.Mvc;
using NeoFilm.Backend.Respositories.Interfaces;
using NeoFilm.Backend.UnitsOfWork.Interfaces;
using NeoFilm.Shared.Dtos;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Implementations
{
    public class TemporalCarUnitOfWork: ITemporalCarUnitOfWork
    {
        private readonly ITemporalCarRepository _repository;

        public TemporalCarUnitOfWork(ITemporalCarRepository repository)
        {
            _repository = repository;
        }
        public virtual async Task<ActionResponse<TemporalCar>> AddAsync(TemporalCar model) => await _repository.AddAsync(model);

        public Task<ActionResponse<TemporalCar>> AddSnacksAsync(int carritoId, [FromBody] SnacksDetailDTO snack) => _repository.AddSnacksAsync(carritoId, snack);

        public Task<ActionResponse<TemporalCar>> AddTicketsAsync(int carritoId, [FromBody] TicketDTO ticket) => _repository.AddTicketsAsync(carritoId, ticket);


        public Task<ActionResponse<Bill>> CreateBillAsync(int carritoId, int paymentId) => _repository.CreateBillAsync(carritoId,  paymentId);


        public virtual async Task<ActionResponse<bool>> ClearCarAsync(int id) => await _repository.ClearCarAsync(id);

        public virtual async Task<ActionResponse<IEnumerable<TemporalCar>>> GetAsync() => await _repository.GetAsync();

        public virtual async Task<ActionResponse<TemporalCar>> UpdateAsync(TemporalCar model) => await _repository.UpdateAsync(model);
    }
}

