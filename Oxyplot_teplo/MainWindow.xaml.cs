
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
using Oxyplot_teplo.ServiceReference1;

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

        //ILogger log = new NLogAdapter();
        int n = 30;

        double time;
        double tau;
        double h;
        double[,] u;
        Draw draw;
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
       
        InputDate inputdate = new InputDate();
        OutputDate outputDate = new OutputDate();
        CulcServiceClient client = new CulcServiceClient();


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
            //натификатор
            //валидация
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

        void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Culc();
            timer.Start();
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
        async void Culc()
        {
            
            if (CheckBoxParallel.IsChecked == true)
            {
                await Task.Run(() =>
                {

                    inputdate.H = h;
                    inputdate.Tau = tau;
                    inputdate.Time = time;

                    inputdate.Mass_u = ToJagged(u);
                    outputDate = client.CulcTeploParal(inputdate);
                    u = ToMultiD(outputDate.Culc_Teplo);
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

                    inputdate.Mass_u = ToJagged(u);
                    outputDate = client.CulcTeploPosl(inputdate);
                    u = ToMultiD(outputDate.Culc_Teplo);
                });
                draw.draw(u);
            }



        }
        bool flag = true;
        private void Start_button_Click(object sender, RoutedEventArgs e)
        {
            StartCulc(flag);
           Culc();
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
                Culc();
        }
    }
}
