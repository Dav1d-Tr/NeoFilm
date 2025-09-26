using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoFilm.Shared
{
    public class Snacks
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public decimal UnitValue { get; set; }
        public string Description { get; set; }
        public bool State {  get; set; }
    }
}
