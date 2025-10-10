using NeoFilm.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoFilm.Shared.CarEntities
{
    public class TemporalSnacksDetail
    {
        public int Id { get; set; }

        [Display(Name = "snack")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int SnackId { get; set; }
        public Snacks Snack { get; set; }

        [Display(Name = "carrito")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int TemporalCarId { get; set; }
        public TemporalCar TemporalCar { get; set; }

        [Display(Name = "cantidad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Quantity { get; set; }

        [Display(Name = "subtotal")]
        public decimal Subtotal { get; set; }
    }
}
