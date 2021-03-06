﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using HelixToolkit.Wpf;

namespace Client3D
{
    class Draw
    {
        int n;
        BoxVisual3D[,,] box;
        public Draw(int _n)
        {
            n = _n;
            box = new BoxVisual3D[n,n,n];
        }

        SolidColorBrush brush = new SolidColorBrush();
        double clr;
        Color color;

        double Max(double[,,] u)
        {
            //int n = u.GetLength(0);
            double max = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (u[i, j,k] > max)
                            max = u[i, j,k];
                    }
                }
            }

            return max;
        }


        public void StartDraw(HelixViewport3D helix)
        {
            brush = new SolidColorBrush(Color.FromRgb(0,0,255));
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        box[i, j,k] = new BoxVisual3D();
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        box[i, j,k].Width = 4;
                        box[i, j, k].Height = 4;
                        box[i, j, k].Length = 4;
                        box[i, j, k].Center = new System.Windows.Media.Media3D.Point3D(10 * i, 10 * j, 10 * k);
                        box[i, j, k].Fill = brush;
                        helix.Children.Add(box[i, j, k]);
                    }
                }
            }
        }

        public void draw(double[,,] u, double TempPlan)
        {

            double max = Max(u);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        clr = (u[i, j, k] * 255) / max;
                        color = Color.FromRgb((byte)clr, 0, (byte)(255 - (int)clr));
                        brush = new SolidColorBrush(color);
                        if (u[i, j, k] < TempPlan+50)
                        {
                            box[i, j, k].Visible = false;
                        }
                        else {
                            box[i, j, k].Visible = true;
                        }
                        
                        box[i, j,k].Fill = brush;
                    }
                }
            }

        }

    }

}
