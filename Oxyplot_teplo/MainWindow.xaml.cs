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
using System.Threading;

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


        int n = 100;

        double time;
        double tau;
        double h;
        double[,] u;
        Draw draw;
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        CulcService calcservice = new CulcService();
        InputDate inputdate = new InputDate();
        OutputDate outputDate = new OutputDate();



        void StartCulc(bool flag)
        {
            Pause_button.Content = "Пауза";
            Pause_button.IsEnabled = true;
            time = 10;
            tau = 0.1;
            h = 1;
            u = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    u[i, j] = Convert.ToDouble(TempPlan.Text);
                }
            }

            for (int j = 0; j < n; j++)
                u[0, j] = Convert.ToDouble(LeftGran.Text);

            for (int i = 0; i < n; i++)
                u[i, n - 1] = Convert.ToDouble(BottomGran.Text);

            for (int j = 0; j < n; j++)
                u[n - 1, j] = Convert.ToDouble(RightGran.Text);

            for (int i = 0; i < n; i++)
                u[i, 0] = Convert.ToDouble(TopGran.Text);

            if (flag)
            {
                timer.Tick += Timer_Tick;
                timer.Interval = new TimeSpan(0,0,1);
                timer.Start();
            }

            draw = new Draw();
            draw.StartDraw(canva);
        }

        async void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            await Culc();
            timer.Start();
        }

        async Task Culc()
        {
            if (CheckBoxParallel.IsChecked == true)
            {
                await Task.Run(() =>
                {

                    inputdate.H = h;
                    inputdate.Tau = tau;
                    inputdate.Time = time;

                    inputdate.Mass_u = CulcService.ToJagged(u);
                    outputDate = calcservice.CulcTeploParal(inputdate);
                    u = CulcService.ToMultiD(outputDate.Culc_Teplo);
                });
                draw.draw(u);
            }
            else
            {
                await Task.Run(() =>
                {

                    inputdate.H = h;
                    inputdate.Tau = tau;
                    inputdate.Time = time;

                    inputdate.Mass_u = CulcService.ToJagged(u);
                    outputDate = calcservice.CulcTeploPosl(inputdate);
                    u = CulcService.ToMultiD(outputDate.Culc_Teplo);
                });
                draw.draw(u);
            }



        }
        bool flag = true;
        async private void Start_button_Click(object sender, RoutedEventArgs e)
        {
            StartCulc(flag);
           await Culc();
            Start_button.IsEnabled = false;
        }

        private void Pause_button_Click(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled == false)
            {
                Pause_button.Content = "Пауза";
                timer.Start();
            }
            else
            {
                Pause_button.Content = "Продолжить";
                timer.Stop();
            }

        }

        private void Stop_button_Click(object sender, RoutedEventArgs e)
        {
            Pause_button.IsEnabled = false;
            timer.Stop();
            Start_button.IsEnabled = true;
        }

        private async void Iter_button_Click(object sender, RoutedEventArgs e)
        {
            int kol = Convert.ToInt32(KolvoIter.Text);
            StartCulc(false);

            for (int i = 0; i < kol; i++)
                await Culc();
        }
    }
}
