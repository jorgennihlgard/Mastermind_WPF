using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mastermind_WPF
{
    public class Point
    {
        private static int _yPosition = 370;
        private static int _xPosition = 130;
       
        private static int _xPositionCodePin = 130;
       // private static int _row = 1;





        public static int GetXPosition()
        {
            if (_xPosition < 250)
            {
                _xPosition += 30;
            }
            else
            {
                _xPosition = 160;
            }
            return _xPosition;

        }

        public static int GetYPosition()
        {

            if (_xPosition == 250)
            {
                _yPosition -= 30;
              
            }

            return _yPosition;

        }

        public static int GetCodePosition()
        {
            return _xPositionCodePin += 30;
        }

    }
}
