using Teplo_WCF_Library;
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
    public class Draw
    {
        const int n = 200;
        public Rectangle[,] rects = new Rectangle[n, n];
        SolidColorBrush brush = new SolidColorBrush();
        double clr;
        Color color;

        public void StartDraw(Canvas canva) {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    rects[i, j] = new Rectangle();
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    rects[i, j].Width = 2;
                    rects[i, j].Height = 2;
                    Canvas.SetLeft(rects[i, j], i * 2);
                    Canvas.SetTop(rects[i, j], j * 2);
                    canva.Children.Add(rects[i, j]);
                }
            }
            canva.InvalidateVisual();
        }

        public void Draw1(double[,] u) {
            
     
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    clr = (u[i, j] * 255) / 500;
                    color = Color.FromRgb((byte)clr, 0, (byte)(255 - (int)clr));
                    brush = new SolidColorBrush(color);
                    rects[i, j].Fill = brush;
                }
            }
        }

    }
}
