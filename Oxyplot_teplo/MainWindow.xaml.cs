using System;
using System.Collections.Generic;
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

namespace Oxyplot_teplo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double[,] _U;
        private Rectangle[,] _Rect;
        private int _sizeX;
        private int _sizeY;
        private double _h;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrepearPaint();
        }

        private void SetStartingValue()
        {
            

        }

        public void PrepearPaint()
        {
            double h = 0.01;
            double [,]u = new double[10,10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    u[i, j] = 1;

            Painter painter = new Painter();
            painter.PrepearDrow(front_canvas, h, 10, 10);
            painter.DrowTemp(u);
            //System.Windows.Shapes.Rectangle rect;
            //rect = new System.Windows.Shapes.Rectangle();
            //rect.Fill = new SolidColorBrush(Colors.Black);
            //rect.Width = 1;
            //rect.Height = 1;
            //Canvas.SetLeft(rect, 0);
            //Canvas.SetTop(rect, 0);
            //front_canvas.Children.Add(rect);
        //    int n = 100;
        //    SolidColorBrush brush = new SolidColorBrush();
        //    brush.Color = Colors.Red;
        //    Rectangle[,] rects = new Rectangle[n, n];
        //    double clr;
        //    Color color;

        
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < n; j++)
        //        {
        //            clr = (u[i, j] * 255) / 500;
        //            color = Color.FromRgb((byte)clr, 0, (byte)(255 - (int)clr));
        //            brush = new SolidColorBrush(color);
        //            rects[i, j] = new Rectangle();
        //            rects[i, j].Fill = brush;
        //            rects[i, j].Width = 10;
        //            rects[i, j].Height = 10;
        //            Canvas.SetLeft(rects[i, j], i * 10);
        //            Canvas.SetTop(rects[i, j], j * 10);
        //            front_canvas.Children.Add(rects[i, j]);
        //        }
        //    }
        //    front_canvas.InvalidateVisual();

        }
    }
}
