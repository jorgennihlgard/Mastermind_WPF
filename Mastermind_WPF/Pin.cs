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
        public string Color { get; set; }
        public int YPos { get; set; }
        public int XPos { get; set; }

        public bool PlayerPin { get; set; }
        

        

      


        
    }
}
