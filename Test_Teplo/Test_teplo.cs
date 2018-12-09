using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeploLibrary;
using System.Diagnostics;

namespace Test_Teplo
{
    [TestClass]
    public class Test_Teplo
    {
        [TestMethod]
        public void Test_Speed_run()
        {
            Teplo teplo = new Teplo();
            Stopwatch timer_posl = new Stopwatch();
            Stopwatch timer_paral = new Stopwatch();
            int n = 100;
            double time = 1;
            double tau = 0.001;
            double h = 1;
            double[,] u = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    u[i, j] = 10;
                }
            }

            for (int j = 0; j < n; j++)
                u[0, j] = 500;

            for (int i = 0; i < n; i++)
                u[i, n - 1] = 500;

            for (int j = 0; j < n; j++)
                u[n - 1, j] = 500;

            for (int i = 0; i < n; i++)
                u[i, 0] = 500;
            timer_posl.Start();
            teplo.PoslCulc(u, time, tau, h);
            timer_posl.Stop();

            timer_paral.Start();
            teplo.ParalCulc(u, time, tau, h);
            timer_paral.Stop();

            bool flag = true;
            if (timer_paral.ElapsedMilliseconds >= timer_posl.ElapsedMilliseconds)
            {
                flag = false;
            }
            Assert.IsFalse(flag, "Нет ускорения");
        }
           // Assert.AreEqual(timer_paral.ElapsedMilliseconds, timer_posl.ElapsedMilliseconds, 0.001);

        [TestMethod]
        public void Test_Rigth_Work_3D()
        {
            Teplo teplo = new Teplo();
            int n = 100;
            double time = 1;
            double tau = 0.001;
            double h = 1;
            double[,,] u = new double[n, n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                        u[i, j, k] = 10;
                }
            }

            for (int i = 0; i < n; i++)
                u[i, 0, 0] = 500;

            teplo.ЗDPoslCulc(u, time, tau, h);

            bool flag = true;
            if (u[50,50,50] < u[n - 1, n - 1, n - 1])
            {
                flag = false;
            }
            Assert.IsFalse(flag, "Считает не правильно");
        }


        
    }
}
