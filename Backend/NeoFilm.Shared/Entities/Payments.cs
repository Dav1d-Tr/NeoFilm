using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoFilm.Shared.Entities
{
    public class Payments
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string Name { get; set; }
        public ICollection<Bill> Bills { get; set; } = new List<Bill>();

    }
}
