
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
        int n;
        Rectangle[,] rects;
        public Draw(int _n){
            n = _n;
            rects = new Rectangle[n, n];
        }
        
        SolidColorBrush brush = new SolidColorBrush();
        double clr;
        Color color;

        double Max(double[,] u)
        {
            //int n = u.GetLength(0);
            double max = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (u[i, j] > max)
                        max = u[i, j];
                }
            }

            return max;
        }


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
                    rects[i, j].Width = 4;
                    rects[i, j].Height = 4;
                    Canvas.SetLeft(rects[i, j], i * 4);
                    Canvas.SetTop(rects[i, j], j * 4);
                    canva.Children.Add(rects[i, j]);
                }
            }
       //     canva.InvalidateVisual();
        }

        public void draw(double[,] u) {

            double max = Max(u);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    clr = (u[i, j] * 255) / max;
                    color = Color.FromRgb((byte)clr, 0, (byte)(255 - (int)clr));
                    brush = new SolidColorBrush(color);
                    rects[i, j].Fill = brush;
                }
            }

        }

    }
}
