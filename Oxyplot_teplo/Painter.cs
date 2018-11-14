using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Oxyplot_teplo
{
    public class Painter
    {
        //private double[,] _U;
        private Rectangle[,]_Rect;
        //private int _sizeX;
        //private int _sizeY;
        //private double _h;

        public Painter()
        {
            
        }

        public void DrowTemp(double [,]u)
        {
            double uMax, uMin;
            uMax = 500;
            uMin = 0;

            int nX = u.GetLength(0);
            int nY = u.GetLength(1);

            for (int i = 0; i < nX; i++)
                for (int j = 0; j < nY; j++)
                {
                    Rectangle rect = _Rect[i, j];
                    byte r, g, b;
                    r = Convert.ToByte(GetColor(u[i, j], uMin, uMax));
                    g = 0;
                    b = r;
                    (rect.Fill as SolidColorBrush).Color = Color.FromRgb(r, g, b);
                }

        }
        private double GetColor(double x, double uMin, double uMax)
        {
            

            double d1 = 0, d2 = 255;

            return ((x - uMin) * (d2 - d1)) / (uMax - uMin) + d1;
        }

        public void PrepearDrow(Canvas canvas, double h, int sizeX, int sizeY)
        {

            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Red;
            Rectangle [,]_Rect = new Rectangle[sizeX, sizeY];

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    //clr = (u[i, j] * 255) / 500;
                    //color = Color.FromRgb((byte)clr, 0, (byte)(255 - (int)clr));
                    brush = new SolidColorBrush();
                    _Rect[i, j] = new Rectangle();
                    _Rect[i, j].Fill = brush;
                    _Rect[i, j].Width = 10;
                    _Rect[i, j].Height = 10;
                    Canvas.SetLeft(_Rect[i, j], i * 10);
                    Canvas.SetTop(_Rect[i, j], j * 10);
                    canvas.Children.Add(_Rect[i, j]);
                }
            }
            
        }

    }
}
