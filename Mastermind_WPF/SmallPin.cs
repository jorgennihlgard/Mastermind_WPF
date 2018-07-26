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
   public class SmallPin
    {
        public int Id { get; set; }
        public PinColor Color { get; set; }
        public Row Row { get; set; }





        public static List<Ellipse> CalculateSmallPins(List<Ellipse> GuessPins, List<Ellipse> CodePins)
        {
            List<Ellipse> SmallPins = new List<Ellipse>();
            int smallPinNumber = 0;
           var ColorGuessArray = GuessPins.Select(g => g.Fill).ToArray();
           var ColorCodeArray = CodePins.Select(c => c.Fill).ToArray();
           
            for (int i = 0; i < 4; i++)
            {
                if (GuessPins[i].Fill.ToString() == CodePins[i].Fill.ToString())
                {
                    Ellipse blackWhitePin1 = new Ellipse();
                    smallPinNumber++;
                    blackWhitePin1.Fill = new SolidColorBrush(Colors.Black);
                    Ellipse newPin = DrawSmallPin(blackWhitePin1, smallPinNumber);
                    SmallPins.Add(newPin);
                    GuessPins[i].Fill = new SolidColorBrush(Colors.AliceBlue);
                    CodePins[i].Fill = new SolidColorBrush(Colors.AntiqueWhite);
                }
            }

            foreach (var correctPin in CodePins)
            {
                foreach (var pinGuess in GuessPins)
                {

                    if (correctPin.Fill.ToString() == pinGuess.Fill.ToString())
                    {
                        Ellipse blackWhitePin = new Ellipse();
                        smallPinNumber++;

                        blackWhitePin.Fill = new SolidColorBrush(Colors.White);
                       Ellipse newPin = DrawSmallPin(blackWhitePin,smallPinNumber);
                        pinGuess.Fill = new SolidColorBrush(Colors.Azure);
                        correctPin.Fill = new SolidColorBrush(Colors.Beige);
                        SmallPins.Add(newPin);
                    }


                    
                }
            }

            for (int i = 0; i < 4; i++)
            {
                GuessPins[i].Fill = ColorGuessArray[i];
                CodePins[i].Fill = ColorCodeArray[i];
            }
            GuessPins.Clear();
            return SmallPins;
        }

        private static Ellipse DrawSmallPin(Ellipse blackWhite, int smallPinNumber)
        {
            blackWhite.Width = 7;
            blackWhite.Height = 7;
            int y = Point.GetYPositionSmallPin(smallPinNumber);
            Canvas.SetTop(blackWhite, y);
            int x = Point.GetXPositionSmallPin(smallPinNumber);
            Canvas.SetLeft(blackWhite, x);

            return blackWhite;
        }

    }
}
