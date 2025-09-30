using NeoFilm.Shared.interfaces;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using NeoFilm.Shared.Entities; // Add this if your User class is in this namespace

namespace NeoFilm.Shared.Entities
{
    public class CategorieSnacks
    {
        public int Id { get; set; }

        [Display(Name = "Categiria del Snack")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string Name { get; set; } = null!;

        public ICollection<Snacks>? Snacks { get; set; }

        public int SnacksNumber => Snacks == null ? 0 : Snacks.Count;
    }
}
