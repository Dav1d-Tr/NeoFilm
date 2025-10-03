using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoFilm.Shared.Entities
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; } = 0;
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public Payments? Payment { get; set; }
        public User? User { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public ICollection<SnacksDetail> SnacksDetails { get; set; } = new List<SnacksDetail>();

    }
}
