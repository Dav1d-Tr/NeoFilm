using System.ComponentModel.DataAnnotations;

namespace NeoFilm.Shared.Entities
{
    public class Function
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Tipo de Formato")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Descripción")]
        [MaxLength(500, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [Display(Name = "Fecha de Función")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La hora es obligatoria.")]
        [Display(Name = "Hora de Función")]
        public TimeSpan Hora { get; set; }

        // Relaciones
        public int FilmId { get; set; }
        public Film? Film { get; set; }

        public int FormatId { get; set; }
        public Format? Format { get; set; }

        public int MovieTheaterId { get; set; }
        public MovieTheater? MovieTheater { get; set; }
    }
}
