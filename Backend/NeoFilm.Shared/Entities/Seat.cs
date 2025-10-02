using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoFilm.Shared.Entities
{
    public class Seat
    {
        public int Id { get; set; }

        [Display(Name = "Fila")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Row { get; set; } = null!;

        [Display(Name = "Número de Asiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Number { get; set; }

        [Display(Name = "Estado")]
        public SeatStatus Status { get; set; } = SeatStatus.Available;

        [Display(Name = "Sala")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int MovieTheaterId { get; set; }

        public MovieTheater? MovieTheater { get; set; }
    }
}