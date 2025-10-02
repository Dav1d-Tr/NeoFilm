using System.ComponentModel.DataAnnotations;

namespace NeoFilm.Shared.Entities
{
    public class Format
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
        public ICollection<Function>? Functions { get; set; }
        public int FunctionsNumber => Functions == null ? 0 : Functions.Count;
    }
}
