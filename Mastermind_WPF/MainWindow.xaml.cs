using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mastermind_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model1 db = new Model1();
        static readonly Random Random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 4; i++)
            {
                Ellipse pin = CreateCode();
                MyCanvas.Children.Add(pin);
               // db.Ellipses.Add(pin);
                //db.SaveChanges();
            }

        }

        private void RedPick_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Ellipse pin = CreatePin();
            pin.Fill = new SolidColorBrush(Colors.Red);
            MyCanvas.Children.Add(pin);

        }

        private void GreenPick_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse pin = CreatePin();
            pin.Fill = new SolidColorBrush(Colors.Green);
            MyCanvas.Children.Add(pin);
        }

        private void BluePick_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse pin = CreatePin();
            pin.Fill = new SolidColorBrush(Colors.Blue);
            MyCanvas.Children.Add(pin);
        }

        private void YellowPick_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse pin = CreatePin();
            pin.Fill = new SolidColorBrush(Colors.Yellow);
            MyCanvas.Children.Add(pin);
        }

        private void PinkPick_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse pin = CreatePin();
            pin.Fill = new SolidColorBrush(Colors.HotPink);
            MyCanvas.Children.Add(pin);
        }

        private void AquamarinePick_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse pin = CreatePin();
            pin.Fill = new SolidColorBrush(Colors.Aquamarine);
            MyCanvas.Children.Add(pin);
        }

        public static Ellipse CreatePin()
        {
            Ellipse pin = new Ellipse();
            pin.Width = 20;
            pin.Height = 20;
            int y = Point.GetYPosition();
            Canvas.SetTop(pin, y);
            int x = Point.GetXPosition();
            Canvas.SetLeft(pin, x);

            return pin;

        }

        public static Ellipse CreateCode()
        {

            Ellipse pin = new Ellipse() { Width = 20, Height = 20 };
            Canvas.SetTop(pin, 60);
            int x = Point.GetCodePosition();
            Canvas.SetLeft(pin, x);
            string color = GetRandomColor();
            SolidColorBrush pinColor = (SolidColorBrush) new BrushConverter().ConvertFromString(color);
            pin.Fill = pinColor;
            return pin;
        }


        public static string GetRandomColor()
        {
            


            string[] colors = { "Red", "Green", "Blue", "Yellow", "HotPink", "AquaMarine" };

            int randomNr = Random.Next(0, 6);

            string color = colors[randomNr];

            return color;

        }

        public static void CorrectRow()
        {

        }
    }
}



























//    public void 
//    {
//        SolidColorBrush ddd = new SolidColorBrush(Colors.Red);
//    SolidColorBrush ddd = new SolidColorBrush(Colors.Green);
//    SolidColorBrush ddd = new SolidColorBrush(Colors.Blue);
//    SolidColorBrush ddd = new SolidColorBrush(Colors.Yellow);

//    Random random = new Random();


//    string[] colors = { "Red", "Green", "Blue", "Yellow", "HotPink", "AquaMarine" };


//    string[] randomColours = new string[6];

//        for (int i = 0; i<colors.Length; i++)
//        {
//            int randomNr = random.Next(0, 6);



//    randomColours[i] = colors[randomNr];

//        }

//SolidColorBrush redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(randomColours[1]);
//SolidColorBrush redB = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
//SolidColorBrush redBrus = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
//Ellipse pin = CreatePin();
//pin.Fill = redBrus;
//        MyCanvas.Children.Add(pin);
//    }

