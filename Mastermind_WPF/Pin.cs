using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind_WPF
{
   public class Pin
    {
        public int Id { get; set; }
        public Color Color { get; set; }
        public Point Point { get; set; }
        public Row Row { get; set; }
        public bool PlayerPin { get; set; }

    }
}
