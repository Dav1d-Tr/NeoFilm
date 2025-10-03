using Microsoft.AspNetCore.Mvc;
using NeoFilm.Shared.Dtos;
using NeoFilm.Shared.Entities;
using NeoFilm.Shared.Responses;

namespace NeoFilm.Backend.UnitsOfWork.Interfaces
{
    public interface ISnacksDetailUnitOfWork
    {
        Task<ActionResponse<SnacksDetail>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<SnacksDetail>>> GetAsync();
        Task<ActionResponse<SnacksDetail>> AddAsync([FromBody] SnacksDetailDTO dto);
    }
}
