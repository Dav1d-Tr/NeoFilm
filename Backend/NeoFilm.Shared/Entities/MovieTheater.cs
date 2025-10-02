using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoFilm.Shared.Entities
{
    public class MovieTheater
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de la sala")] //campo que le mostrara al usuario
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas un {1} caracter")]//maxima longitud del campo
        [Required(ErrorMessage = "El campo {0} es obligatorio.")] //Para no aceptar nulos
        public string Name { get; set; } = null!;

        [Display(Name = "Id Sede")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int VenueId { get; set; }

        [Display(Name = "Capacidad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Capacity { get; set; }

        public Venue? Venue { get; set; }

        public ICollection<Seat>? Seats { get; set; }

        public ICollection<Function>? Functions { get; set; }
    }
}