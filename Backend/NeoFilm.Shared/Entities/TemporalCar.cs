using NeoFilm.Shared.CarEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoFilm.Shared.Entities
{
    public class TemporalCar
    {
        public int Id { get; set; }
        [Display(Name = "usuario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string UserId { get; set; }

        public User? User { get; set; }

        public ICollection<TemporalTicket> Tickets { get; set; } = new List<TemporalTicket>();
        public ICollection<TemporalSnacksDetail> TemporalSnacksDetail { get; set; } = new List<TemporalSnacksDetail>();
        public decimal Total { get; set; } = 0;
        [Display(Name = "comentarios")]
        public string? comments { get; set; } 

    }
}
