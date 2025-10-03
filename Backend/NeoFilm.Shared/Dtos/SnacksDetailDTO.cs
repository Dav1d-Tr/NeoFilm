using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoFilm.Shared.Dtos
{
    public class SnacksDetailDTO
    {

        [Required]
        public int SnackId { get; set; }

        [Required]
        public int BillId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
