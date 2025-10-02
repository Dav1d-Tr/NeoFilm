using System.ComponentModel.DataAnnotations;

namespace NeoFilm.Shared.Entities
{
    public class CategorieFilms
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Tipo de Categoría")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string Name { get; set; } = null!;
        public ICollection<Film>? Films { get; set; }
        public int FilmsNumber => Films == null ? 0 : Films.Count;
    }
}
