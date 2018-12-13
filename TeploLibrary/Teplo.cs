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

        public static T[][] ToJagged<T>(T[,] mArray)
        {
            var rows = mArray.GetLength(0);
            var cols = mArray.GetLength(1);
            var jArray = new T[rows][];
            for (int i = 0; i < rows; i++)
            {
                jArray[i] = new T[cols];
                for (int j = 0; j < cols; j++)
                {
                    jArray[i][j] = mArray[i, j];
                }
            }
            return jArray;
        }
        public static T[][][] ToJagged3D<T>(T[,,] mArray)
        {
            var rows = mArray.GetLength(0);
            var cols = mArray.GetLength(1);
            var wight = mArray.GetLength(2);
            var jArray = new T[rows][][];
            for (int i = 0; i < rows; i++)
            {
                jArray[i] = new T[cols][];
                for (int j = 0; j < cols; j++)
                {
                    jArray[i][j] = new T[wight];
                }

            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    for (int k = 0; k < wight; k++)
                    {
                        jArray[i][j][k] = mArray[i, j, k];
                    }
                }

            }

            return jArray;
        }

        public static T[,] ToMultiD<T>(T[][] jArray)
        {
            int i = jArray.Count();
            int j = jArray.Select(x => x.Count()).Aggregate(0, (current, c) => (current > c) ? current : c);

            var mArray = new T[i, j];

            for (int ii = 0; ii < i; ii++)
            {
                for (int jj = 0; jj < j; jj++)
                {
                    mArray[ii, jj] = jArray[ii][jj];
                }
            }

            return mArray;
        }

        public static T[,,] ToMulti3D<T>(T[][][] jArray)
        {
            int i = jArray.Count();
            int j = jArray.Select(x => x.Count()).Aggregate(0, (current, c) => (current > c) ? current : c);
            int k = jArray[0][0].Length;

            var mArray = new T[i, j, k];

            for (int ii = 0; ii < i; ii++)
            {
                for (int jj = 0; jj < j; jj++)
                {
                    for (int kk = 0; kk < k; kk++)
                    {
                        mArray[ii, jj, kk] = jArray[ii][jj][kk];
                    }
                }
            }

            return mArray;
        }


        public double[,] PoslCulc(double[,] u, double time, double tau, double h)
        {
            _Logger.Log("Запущен последовательный расчет ");
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
