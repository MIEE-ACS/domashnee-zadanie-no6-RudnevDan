using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
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

namespace hw6_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    abstract class Figure
    {
        public int a;
        public int b;

        public abstract double Perimetr();
        public abstract double Square();

        public int a_side { get { return a; } set { a = value; } }
        public int b_side { get { return b; } set { b = value; } }
    }

    class Circle : Figure
    {
        public Circle(int radius)
        {
            a = radius;
        }
        public override double Perimetr()
        {
            double p = Math.PI * 2 * a;
            return p;
        }
        public override double Square()
        {
            double s = Math.PI * Math.Pow(a, 2);
            return s;
        }
    }
    class Rectangle : Figure
    {
        public Rectangle(int length, int widthness)
        {
            a = length;
            b = widthness;

        }

        public override double Perimetr()
        {
            double p = 2 * (a + b);
            return p;
        }

        public override double Square()
        {
            double s = a * b;
            return s;
        }

    }

    class Trapezoid : Figure
    {
        public int h;
        public int h_side { get { return h; } set { h = value; } }
        public Trapezoid(int Foundation1, int Foundation2, int Heigh)
        {
            a = Foundation1;
            b = Foundation2;
            h = Heigh;
        }

        public override double Perimetr()
        {
            double p = a + b + 2 * Math.Sqrt(Math.Pow(h, 2) + Math.Pow(a-b,2)/4);
            return p;
            
        }
        public override double Square()
        {
            double s = (a + b) * h * 0.5;
            return s;
        }
    }

    //public int circlescount = 3;
    //public int circlescount = 3;
    //public int circlescount = 3;
    //Circle[]

    public partial class MainWindow : Window
    {
        public static int circlescount = 3;
        public static int rectanglescount = 3;
        public static int trapezoidscount = 3;
        Circle[] circles = new Circle[circlescount];
        Rectangle[] rectangles = new Rectangle[rectanglescount];
        Trapezoid[] trapezoids = new Trapezoid[trapezoidscount];

        public void Clear_Fields()
        {
            CircleNumbeLabel.Content = "";
            CircleRadiusLabel.Content = "";
            CircleLengthLabel.Content = "";
            CircleSquareLabel.Content = "";
            RectangleNumbeLabel.Content = "";
            RectangleLengthLabel.Content = "";
            RectangleSquareLabel.Content = "";
            RectangleWidthLabel.Content = "";
            RectanglePerimetrLabel.Content = "";
            TrapezoidNumbeLabel.Content = "";
            TrapezoidBase1Label.Content = "";
            TrapezoidBase2Label.Content = "";
            TrapezoidHeightLabel.Content = "";
            TrapezoidPerimetrLabel.Content = "";
            TrapezoidSquareLabel.Content = "";
        }

        public void Update_Fields()
        {
            Clear_Fields();
            for(int i = 0; i < circlescount; i++)
            {
                CircleNumbeLabel.Content += String.Format("\n{0}",i+1);
                CircleRadiusLabel.Content += String.Format("\n{0}", circles[i].a_side);
                CircleLengthLabel.Content += String.Format("\n{0:0.00}", circles[i].Perimetr());
                CircleSquareLabel.Content += String.Format("\n{0:0.00}", circles[i].Square());
            }
            for(int i = 0; i < rectanglescount; i++)
            {
                RectangleNumbeLabel.Content += String.Format("\n{0}", i+1);
                RectangleLengthLabel.Content += String.Format("\n{0}", rectangles[i].b_side);
                RectangleSquareLabel.Content += String.Format("\n{0:0.00}", rectangles[i].Square());
                RectangleWidthLabel.Content += String.Format("\n{0}", rectangles[i].a_side);
                RectanglePerimetrLabel.Content += String.Format("\n{0:0.00}", rectangles[i].Perimetr());
            }
            for(int i = 0; i < trapezoidscount; i++)
            {
                TrapezoidNumbeLabel.Content += String.Format("\n{0}", i + 1);
                TrapezoidBase1Label.Content += String.Format("\n{0}", trapezoids[i].a_side);
                TrapezoidBase2Label.Content += String.Format("\n{0}", trapezoids[i].b_side);
                TrapezoidHeightLabel.Content += String.Format("\n{0}", trapezoids[i].h_side);
                TrapezoidPerimetrLabel.Content += String.Format("\n{0:0.00}", trapezoids[i].Perimetr());
                TrapezoidSquareLabel.Content += String.Format("\n{0:0.00}", trapezoids[i].Square());
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            //Trapezoid ex = new Trapezoid(2, 4, 3);
            //MessageBox.Show(ex.Perimetr().ToString());
            //for (int i = 2; i < 20; i++) CircleNumbeLabel.Content += String.Format("\n{0}",i);
            for(int i = 0; i < circlescount; i++)
            {
                circles[i] = new Circle(10);                
            }
            for(int i = 0; i < rectanglescount; i++)
            {
                rectangles[i] = new Rectangle(10,5);
            }
            for(int i = 0; i< trapezoidscount; i++)
            {
                trapezoids[i] = new Trapezoid(10,15,5);
            }
            Update_Fields();
        }

        private void AddingButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddingWindow();
            window.Owner = this;
            window.ShowDialog();
            if(window.DialogResult == true)
            {
                switch(window.selectbox.SelectedIndex)
                {
                    case 0:
                        circlescount++;
                        Array.Resize(ref circles, circlescount);
                        circles[circlescount - 1] = new Circle(window.a);
                        Update_Fields();
                        break;
                    case 1:
                        rectanglescount++;
                        Array.Resize(ref rectangles, rectanglescount);
                        rectangles[rectanglescount - 1] = new Rectangle(window.a, window.b);
                        Update_Fields();
                        break;
                    case 2:
                        trapezoidscount++;
                        Array.Resize(ref trapezoids, trapezoidscount);
                        trapezoids[trapezoidscount - 1] = new Trapezoid(window.a, window.b, window.h);
                        Update_Fields();
                        break;
                }
            }
        }

        private void RemovingButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new RemovingWindow();
            window.Owner = this;
            window.ShowDialog();
            if(window.DialogResult == true)
            {
                switch (window.selectbox.SelectedIndex)
                {
                    case 0:
                        for(int i = window.remnum; i < circlescount; i++)
                        {
                            circles[i - 1] = circles[i];
                        }
                        circlescount--;
                        Array.Resize(ref circles, circlescount);
                        break;
                    case 1:
                        for (int i = window.remnum; i < rectanglescount; i++)
                        {
                            rectangles[i - 1] = rectangles[i];
                        }
                        rectanglescount--;
                        Array.Resize(ref rectangles, rectanglescount);
                        break;
                    case 2:
                        for (int i = window.remnum; i < trapezoidscount; i++)
                        {
                            trapezoids[i - 1] = trapezoids[i];
                        }
                        trapezoidscount--;
                        Array.Resize(ref trapezoids, trapezoidscount);
                        break;
                }
                Update_Fields();
            }
        }
    }
}
