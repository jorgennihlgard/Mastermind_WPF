using System;
using System.Collections.Generic;
using System.Data;
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
        private Pin pinne = null;
        List<Ellipse> CodePins = new List<Ellipse>();
        List<Ellipse> GuessPins = new List<Ellipse>();
        

        string[] correctColour = new string[4];
        static int pinCount = 0;
        Model3 db = new Model3();
        static readonly Random Random = new Random();
        public MainWindow()
        {

            InitializeComponent();

            //DataSet circle = MakeDataTable();
            Ellipse pin = null;

            for (int i = 0; i < 4; i++)
            {
                pin = CreateCode();

                correctColour[i] = pin.Fill.ToString();
                CodePins.Add(pin);
                pin.Visibility = Visibility.Hidden;
                //AddTableRows(circle, pin);
                MyCanvas.Children.Add(pin);

            }

            //Save(circle);

        }

        private void RedPick_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Ellipse pin = CreatePin();
            pin.Fill = new SolidColorBrush(Colors.Red);
            //MyCanvas.Children.Add(pin);
            //GuessPins.Add(pin);
            checkNumberPinsInRow(pin);
        }

        private void GreenPick_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse pin = CreatePin();
            pin.Fill = new SolidColorBrush(Colors.Green);
            //MyCanvas.Children.Add(pin);
            //GuessPins.Add(pin);
            checkNumberPinsInRow(pin);
            Pin pi = new Pin();
            pi.Color = pin.Fill.ToString();
            //SaveNow(pi);
        }

        private void BluePick_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse pin = CreatePin();
            pin.Fill = new SolidColorBrush(Colors.Blue);
            //MyCanvas.Children.Add(pin);
            //GuessPins.Add(pin);
            checkNumberPinsInRow(pin);
        }

        private void YellowPick_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse pin = CreatePin();
            pin.Fill = new SolidColorBrush(Colors.Yellow);
            checkNumberPinsInRow(pin);
           

        }

        

        private void PinkPick_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse pin = CreatePin();
            pin.Fill = new SolidColorBrush(Colors.HotPink);
            //MyCanvas.Children.Add(pin);
            //GuessPins.Add(pin);
            checkNumberPinsInRow(pin);
        }

        private void AquamarinePick_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse pin = CreatePin();
            pin.Fill = new SolidColorBrush(Colors.Aquamarine);
            //MyCanvas.Children.Add(pin);
            //GuessPins.Add(pin);
            checkNumberPinsInRow(pin);
            
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
            pinCount++;
            return pin;

        }

        public static Ellipse CreateCode()
        {

            Ellipse pin = new Ellipse() { Width = 20, Height = 20 };
            Canvas.SetTop(pin, 60);
            int x = Point.GetCodePosition();
            Canvas.SetLeft(pin, x);
            string color = GetRandomColor();
            SolidColorBrush pinColor = (SolidColorBrush)new BrushConverter().ConvertFromString(color);
            pin.Fill = pinColor;
            return pin;
        }

        public void checkNumberPinsInRow(Ellipse pin)
        {
            MyCanvas.Children.Add(pin);
            GuessPins.Add(pin);
            if (pinCount % 4 == 0)
            {
                List<Ellipse> smallPins = SmallPin.CalculateSmallPins(GuessPins, CodePins);
                int countBlack = 0;
                Message();
                foreach (var item in smallPins)
                {

                    if (item.Fill.ToString() == "#FF000000")
                    {
                        countBlack++;
                        if (countBlack == 4)
                        {
                            foreach (var item2 in CodePins)
                            {
                                item2.Visibility = Visibility.Visible;
                            }
                            MessageBox.Show("Grattis, du är dagens vinnare");
                            
                        }
                    }
                    MyCanvas.Children.Add(item);
                    
                    
                }

            }

        }

        public static void Message()
        {
            // Configure the message box to be displayed
            string messageBoxText = "Vill du spela igen?";
            string caption = "Mastermind";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;

           MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                    break;
                case MessageBoxResult.No:
                    Application.Current.Shutdown();
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Njut av segern..");
                    break;
            }
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

        public static DataSet MakeDataTable()
        {
            DataSet game = new DataSet("MyGameTables");
            DataTable circle = game.Tables.Add("MyPins");
            DataTable peg = game.Tables.Add("MyPegs");

            circle.Columns.Add("Id", typeof(int));
            circle.Columns.Add("Color", typeof(string));
            circle.Columns.Add("YPos");
            circle.Columns.Add("XPos");
            peg.Columns.Add("Id", typeof(int));
            peg.Columns.Add("aa", typeof(string));
            peg.Columns.Add("bbb");
            peg.Columns.Add("cccc");

            return game;


        }

        public static void AddTableRows(DataSet cir, Ellipse pin)
        {

            DataRow row = cir.Tables[0].NewRow();
            DataRow pegrow = cir.Tables[1].NewRow();
            row["Id"] = 1;
            row["Color"] = pin.Fill;
            row["YPos"] = pin.GetValue(Canvas.TopProperty);
            row["XPos"] = pin.GetValue(Canvas.LeftProperty);
            pegrow["Id"] = 1;
            pegrow["aa"] = pin.Fill;
            pegrow["bbb"] = pin.GetValue(Canvas.TopProperty);
            pegrow["cccc"] = pin.GetValue(Canvas.LeftProperty);

            cir.Tables[0].Rows.Add(row);
            cir.Tables[1].Rows.Add(pegrow);



            // Pin newPin = new Pin();

            //newPin.Id += Convert.ToInt32(row["Id"]);
            //newPin.Color += row["Color"].ToString();
            //newPin.YPos += Convert.ToInt32(row["YPos"]);
            //newPin.XPos += Convert.ToInt32(row["XPos"]);
            //MessageBox.Show(thisRow["Color"] + " " + thisRow["Id"] + " " + thisRow["YPos"] + " " + thisRow["xPos"]);


            // return newPin;



        }

        public void Save(DataSet pin)
        {
            //    foreach (DataColumn dd in pin.Tables["0"].Columns)
            //    {
            //        dd.
            //    }

            //    pinss.Color = pin.Tables["0"];
            //    db.Pins.Add(pin.Tables["0"]);       //HÄR ÄR JAG........................
            //    db.SaveChanges();
        }

        public void SaveNow(Pin pin)
        {
            db.Pins.Add(pin);
            db.SaveChanges();
        }

//        using (var context = new MyContext())
//{
//    try
//    {
//        foreach(var row in accounts){
//            context.AddToAccounts(row);
//        }
//context.SaveChanges();
//    }catch (Exception ex){
//        //Log any exception here.
//    }     
//}
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

