using System.ComponentModel.DataAnnotations;

namespace NeoFilm.Shared.Entities
{
    public class Film
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Nombre")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Descripción")]
        [MaxLength(500, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1, 500, ErrorMessage = "La duración debe estar entre {1} y {2} minutos.")]
        [Display(Name = "Duración (minutos)")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Distribución")]
        [MaxLength(500, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string Distribution { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Imagen")]
        [Url(ErrorMessage = "El campo {0} debe ser una URL válida.")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Tráiler")]
        [Url(ErrorMessage = "El campo {0} debe ser una URL válida.")]
        public string Trailer { get; set; } = null!;

        [Required(ErrorMessage = "Debe seleccionar una categoría.")]
        [Display(Name = "Categoría")]
        public int CategorieFilmsId { get; set; }
        public CategorieFilms? CategorieFilms { get; set; }
        public ICollection<Function>? Functions { get; set; }
        public int FunctionsNumber => Functions == null ? 0 : Functions.Count;
    }
}
