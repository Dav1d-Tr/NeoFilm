using Microsoft.AspNetCore.Mvc;
using NeoFilm.Shared.Dtos;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.Respositories.Interfaces
{
    public interface ITicketsRepository
    {
        Task<ActionResponse<Ticket>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Ticket>>> GetAsync();
        Task<ActionResponse<Ticket>> AddAsync([FromBody] TicketDTO dto);
        Task<ActionResponse<Ticket>> DeleteAsync(int id);
    }
}
