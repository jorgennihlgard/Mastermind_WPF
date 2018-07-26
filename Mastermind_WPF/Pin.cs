using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Mastermind_WPF
{
   public class Pin
    {
        [Key]
        public int Id { get; set; }
        public PinColor PinColor { get; set; }
        public Row Row { get; set; }


    }
}
