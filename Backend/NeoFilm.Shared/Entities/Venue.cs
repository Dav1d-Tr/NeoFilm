using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoFilm.Shared.Entities
{
    public class Venue
    {
        public int Id { get; set; }

        [Display(Name = "Ubicación")] //campo que le mostrara al usuario
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener mas un {1} caracter")]//maxima longitud del campo
        [Required(ErrorMessage = "El campo {0} es obligatorio.")] //Para no aceptar nulos
        public string Location { get; set; } = null!;

        [Display(Name = "Nombre")]
        [MaxLength(30)]
        public string Name { get; set; } = null!;

        public ICollection<MovieTheater>? MovieTheaters { get; set; }
    }
}