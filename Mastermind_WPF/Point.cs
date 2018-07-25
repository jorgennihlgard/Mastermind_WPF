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

        private static int _yPositionSmallPin = 383;
        private static int _xPositionSmallPin = 295;
        


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

        public static int GetXPositionSmallPin(int pinCount)
        {
            if(pinCount == 1 || pinCount == 3)
            {
                _xPositionSmallPin = 295;
            }
            else
            {
                _xPositionSmallPin = 305;
                
            }
            
            return _xPositionSmallPin;
        }

        public static int GetYPositionSmallPin(int pinCount)
        {
            if (pinCount == 1 || pinCount == 2)
            {
                _yPositionSmallPin = _yPosition + 13;
            }
            else
            {
                _yPositionSmallPin = _yPosition + 3;
                
            }

            return _yPositionSmallPin;
        }


        public static void CalculateYSmallPin()
        {


            
        }













        public static int GetYPositi()
        {

            if (_xPositionSmallPin > 295)
            {
                _yPositionSmallPin = _yPosition + 3;

            }
            else
            {
                _yPositionSmallPin = _yPosition + 13;
                //_xPositionSmallPin = 295;
            }

            if (_xPositionSmallPin <= 295)
            {
                _xPositionSmallPin += 10;
            }
            else
            {
                _xPositionSmallPin = 295;
                
            }


            return _yPositionSmallPin;
        }


    }
}
