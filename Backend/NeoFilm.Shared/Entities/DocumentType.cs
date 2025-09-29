using NeoFilm.Shared.interfaces;
using NeoFilm.Shared.Entities; 
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NeoFilm.Shared.Entities
{
    public class DocumentType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Documento")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string Name { get; set; } = null!;

        public ICollection<User>? Users { get; set; }
        public int UsersNumber => Users == null ? 0 : Users.Count;

    }
}
