using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoFilm.Shared.Entities
{
    public class SnacksDetail
    {
        public int Id { get; set; }
        [Display(Name = "snacks")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int SnackId { get; set; }
        public Snacks Snack { get; set; }
        [Display(Name = "Factura")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int BillId { get; set; }
        public Bill Bill { get; set; }
        [Display(Name = "cantidad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Quantity { get; set; }
        public decimal subtotal { get; set; } = 0;
    }
}
