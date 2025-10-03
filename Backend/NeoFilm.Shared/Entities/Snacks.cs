using NeoFilm.Shared.interfaces;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NeoFilm.Shared.Entities
{
    public class Snacks : IProducto
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string Name { get; set; }
        [Display(Name = "valor unitario")]
        [Range(0, 1000000.99)]
        public decimal UnitValue { get; set; }

        [MaxLength(500, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "descripcion")]
        public string Description { get; set; }
        [Display(Name = "estado")]
        public bool State { get; set; }
        public string imageUrl { get; set; }    
        public int CategorieSnacksId { get; set; }
        public CategorieSnacks? CategorieSnacks { get; set; }
        public string GetDescripcion() => $"Snack: {Name}, precio: {UnitValue}";
        public ICollection<SnacksDetail> Tickets { get; set; } = new List<SnacksDetail>();
    }
}
