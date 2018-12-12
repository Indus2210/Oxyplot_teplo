using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeploLibrary
{
    public class Teplo
    {
        private ILogger _Logger;

        public Teplo(ILogger logger)
        {
            SetLogger(logger);
        }

        public Teplo()
        {

        }

        public void SetLogger(ILogger logger)
        {
            _Logger = logger;
        }

        public double[,] PoslCulc(double[,] u, double time, double tau, double h)
        {
            _Logger.Log("Запущен последовательный расчет");
            int a = u.GetLength(0);
            int b = u.GetLength(1);
            double[,] unew = new double[a, b];
            double Eps = tau / (h * h);
            unew = u;
            double t0 = 0;
            for (double t = t0 + tau; t <= time; t += tau)
            {
                for (int i = 1; i < a - 1; i++)
                    for (int j = 1; j < b - 1; j++)
                        unew[i, j] = u[i, j] + Eps * (u[i + 1, j] + u[i - 1, j] + u[i, j + 1] + u[i, j - 1] - 4 * u[i, j]);

                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        u[i, j] = unew[i, j];
                    }
                }
            }
            if (_Logger != null)
            {
                _Logger.Log("Закончен последовательный расчет");
            }
            return u;
        }

        public double[,,] PoslCulс3D(double[,,] u, double time, double tau, double h)
        {
            int a = u.GetLength(0);
            int b = u.GetLength(1);
            int c = u.GetLength(2);
            double[,,] unew = new double[a, b, c];
            double Eps = tau / (h * h);
            unew = u;
            double t0 = 0;
            for (double t = t0 + tau; t <= time; t += tau)
            {
                for (int i = 1; i < a - 1; i++)
                    for (int j = 1; j < b - 1; j++)
                        for (int k = 1; k < c - 1; k++)
                            unew[i, j, k] = u[i, j, k] + Eps * (u[i + 1, j, k] + u[i - 1, j, k] + u[i, j + 1, k] + u[i, j - 1, k] + u[i, j, k - 1] + u[i, j, k + 1] - 6 * u[i, j, k]);

                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        for (int k = 0; k < c; k++)
                        {
                            u[i, j, k] = unew[i, j, k];
                        }
                    }
                }
            }

            return u;
        }

        public double[,] ParalCulc(double[,] u, double time, double tau, double h)
        {
            _Logger.Log("Запущен паралельный рассчет расчет");
            int a = u.GetLength(0);
            int b = u.GetLength(1);
            double[,] unew = new double[a, b];
            double Eps = tau / (h * h);
            unew = u;
            double t0 = 0;
            for (double t = t0 + tau; t <= time; t += tau)
            {
                for (int i = 1; i < a - 1; i++)
                {
                    Parallel.For(1, b - 1, j =>
                   {
                       unew[i, j] = u[i, j] + Eps * (u[i + 1, j] + u[i - 1, j] + u[i, j + 1] + u[i, j - 1] - 4 * u[i, j]);
                   });
                }



                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        u[i, j] = unew[i, j];
                    }
                }
            }
            if (_Logger != null)
            {
                _Logger.Log("Закончен паралельный расчет");
            }
            return u;
        }

        public double[,,] ЗDParalCulc(double[,,] u, double time, double tau, double h)
        {
            int a = u.GetLength(0);
            int b = u.GetLength(1);
            int c = u.GetLength(2);
            double[,,] unew = new double[a, b, c];
            double Eps = tau / (h * h);
            unew = u;
            double t0 = 0;
            for (double t = t0 + tau; t <= time; t += tau)
            {
                for (int i = 1; i < a - 1; i++)
                    for (int j = 1; j < b - 1; j++)
                        Parallel.For(1, c - 1, k =>
                        {
                            unew[i, j, k] = u[i, j, k] + Eps * (u[i + 1, j, k] + u[i - 1, j, k] + u[i, j + 1, k] + u[i, j - 1, k] + u[i, j, k - 1] + u[i, j, k + 1] - 6 * u[i, j, k]);
                        });


                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        for (int k = 0; k < c; k++)
                        {
                            u[i, j, k] = unew[i, j, k];
                        }
                    }
                }
            }

            return u;
        }

    }
}
