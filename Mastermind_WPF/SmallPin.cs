using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace Mastermind_WPF
{
    class SmallPin
    {
        public string Color { get; set; }
        public int YPos { get; set; }
        public int XPos { get; set; }
        


        public static List<Ellipse> CalculateSmallPins(List<Ellipse> GuessPins, List<Ellipse> CodePins)
        {
            List<Ellipse> SmallPins = new List<Ellipse>();
            int smallPinNumber = 0;
            string lastColor ="";
            foreach (var correctPin in CodePins)
            {
                foreach (var pinGuess in GuessPins)
                {
                    if (correctPin.Fill.ToString() == pinGuess.Fill.ToString())
                    {
                        Ellipse blackWhitePin = new Ellipse();
                        smallPinNumber++;

                        if (correctPin.GetValue(Canvas.LeftProperty).ToString() == pinGuess.GetValue(Canvas.LeftProperty).ToString() && pinGuess.Fill.ToString() != )
                        {
                            blackWhitePin.Fill = new SolidColorBrush(Colors.Black);
                            lastColor = correctPin.Fill.ToString();
                        }
                        else
                        {
                            blackWhitePin.Fill = new SolidColorBrush(Colors.White);
                        }

                        blackWhitePin.Width = 7;
                        blackWhitePin.Height = 7;
                        int y = Point.GetYPositionSmallPin(smallPinNumber);
                        Canvas.SetTop(blackWhitePin, y);
                        int x = Point.GetXPositionSmallPin(smallPinNumber);
                        Canvas.SetLeft(blackWhitePin, x);
                        SmallPins.Add(blackWhitePin);
                    }

                   

                }
            }
            GuessPins.Clear();
            return SmallPins;
        }

    }
}
