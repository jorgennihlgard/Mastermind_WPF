using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind_WPF
{
    public class Cooolor
    {
        public int Id { get; set; }
        public string Red { get; set; }
        public string Green { get; set; }
        public string Blue { get; set; }


        Random random = new Random();

        public Cooolor()
        {
            Red = "Red";
            Green = "Green";
            Blue = "Blue";
        }

        

        public static Cooolor GetColors()
        {
            Cooolor cc = new Cooolor() { Red = "Red"  };
            //string[] colors= new string[5];00
            //for (int i = 0; i < colorArray.Length; i++)
            //{
            //    int colorPosition = random.Next(0, 5);
            //    colors[i] = colorArray[colorPosition];
            //}
            //Colors = colors;
            
            return cc;
        }

    }
}
