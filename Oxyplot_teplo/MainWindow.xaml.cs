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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// Получить массив массивов (jagged array) из обычного двухмерного массива
        /// </summary>
        /// <typeparam name="T">Тип .NET</typeparam>
        /// <param name="mArray">Двухмерный массив</param>
        /// <returns>Массив массивов (Jagged array)</returns>
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
        

        void Test() {
            int n = 10;
            double time = 0.1;
            double tau = 0.0001;
            double h = 1;
            double[,] u = new double[n, n];
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++)
                {
                    u[i, j] = 10;
                } 
            }

            for (int j = 0; j < n; j++)
                u[0,j] = 500;

            for (int i = 0; i < n; i++)
                u[i,n - 1] = 500;

            for (int j = 0; j < n; j++)
                u[n - 1,j] = 500;

            for (int i = 0; i < n; i++)
                 u[i,0] = 500;

            CulcService calcservice = new CulcService();
            InputDate inputdate = new InputDate();
            OutputDate outputDate = new OutputDate();
            inputdate.H = h;
            inputdate.Tau = tau;
            inputdate.Time = time;
            inputdate.Mass_u = ToJagged(u);
            
              //  inputdate.Mass_u = u;
            outputDate = calcservice.CulcTeploPosl(inputdate);

            u = ToMultiD(outputDate.Culc_Teplo);



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Test();
        }

    }
}
