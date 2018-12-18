using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeploLibrary;
using System.Diagnostics;
using Moq;

namespace Test_Teplo
{
    [TestClass]
    public class Test_Teplo
    {
        [TestMethod]
        public void Test_Speed_run()
        {
            Mock<ILogger> stubLogger = new Mock<ILogger>();
            Teplo teplo = new Teplo(stubLogger.Object);

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

        [TestMethod]
        public void Test_Rigth_Work_3D()
        {
            Mock<ILogger> stubLogger = new Mock<ILogger>();
            Teplo teplo = new Teplo(stubLogger.Object);

            int n = 10;
            double time = 10;
            double tau = 0.01;
            double h = 1;
            double[,,] u = new double[n, n, n];
            double[,,] unew = new double[n, n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                        u[i, j, k] = unew[i, j, k] = 10;
                }
            }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    u[i, j, 0] = unew[i, j, 0] = 50;

            unew = teplo.PoslCulс3D(u, time, tau, h);

            bool flag = false;
            if (unew[1, 1, 1] < unew[n - 2, n - 2, n - 2])

            {
                flag = true;
            }
            Assert.IsFalse(flag, "Считает не правильно");
        }

        [TestMethod]
        public void Test_Equality_Parallel_And_Posl_Metods()
        {
            Mock<ILogger> stubLogger = new Mock<ILogger>();
            Teplo teplo = new Teplo(stubLogger.Object);

            int n = 100;
            double time = 1;
            double tau = 0.001;
            double h = 1;
            double[,] u = new double[n, n];
            double[,] uposl = new double[n, n];
            double[,] uparallel = new double[n, n];

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

            uposl = teplo.PoslCulc(u, time, tau, h);
            uparallel = teplo.ParalCulc(u, time, tau, h);

            Assert.AreEqual(uposl, uparallel);
        }     
        
    }
}
