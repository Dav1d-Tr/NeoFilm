using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoFilm.Shared.Dtos
{
    public class TicketDTO
    {

        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int BillId { get; set; }
        [Required]
        public int FunctionId { get; set; }
        [Required]
        public int SeatId { get; set; }
    }
}
