using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind_WPF
{
    public class Row
    {
        public int Id { get; set; }
        public List<Pin> Pin { get; set; }
        public List<SmallPin> SmallPin { get; set; }
        public DateTime Time { get; set; }

        public Row()
        {
            Time = DateTime.Now;
        }



    }
}
