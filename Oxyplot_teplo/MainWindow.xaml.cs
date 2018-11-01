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
            inputdate.Mass_u = u;
            outputDate = calcservice.CulcTeploParal(inputdate);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Test();
        }

    }
}
