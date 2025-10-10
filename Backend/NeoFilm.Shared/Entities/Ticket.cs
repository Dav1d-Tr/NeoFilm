using NeoFilm.Shared.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NeoFilm.Shared.Entities
{
    public class Ticket: IProducto
    {
        public int Id { get; set; }
        public string Description { get; set; }

        [Display(Name = "precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Price { get; set; }
        [Display(Name = "Factura")]

        public int? BillId { get; set; }
        public Bill? Bill { get; set; }
        [Display(Name = "Funcion")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int FunctionId { get; set; }
        public Function Function { get; set; }
        [Display(Name = "Asiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int SeatId { get; set; }
        public Seat Seat { get; set; }

        
        public string GetDescripcion() => Description;

    }
}
