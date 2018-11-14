﻿using Teplo_WCF_Library;
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


        int n = 200;

        double time;
        double tau;
        double h;
        double[,] u;
        Draw draw;
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        CulcService calcservice = new CulcService();
        InputDate inputdate = new InputDate();
        OutputDate outputDate = new OutputDate();
        void StartCulc()
        {
            time = 100;
            tau = 0.1;
            h = 1;
            u = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    u[i, j] =Convert.ToDouble(TempPlan.Text);
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

            
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(5);
            timer.Start();

            draw = new Draw();
            draw.StartDraw(canva);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Test();
        }

        void Test()
        {

            var task = Task.Run(() => {
                
                inputdate.H = h;
                inputdate.Tau = tau;
                inputdate.Time = time;

                inputdate.Mass_u = CulcService.ToJagged(u);
                outputDate = calcservice.CulcTeploPosl(inputdate);
                u = CulcService.ToMultiD(outputDate.Culc_Teplo);

                
            });
            draw.Draw1(u);
            canva.InvalidateVisual();
            

        }
        bool flag = true;
        private void Start_button_Click(object sender, RoutedEventArgs e)
        {
            StartCulc();
            Test();
            Start_button.IsEnabled = false;
        }

        private void Pause_button_Click(object sender, RoutedEventArgs e)
        {
            if(flag == false){
                Pause_button.Content = "Пауза";
                flag = true;
                timer.Start();
            }
            else{
                Pause_button.Content = "Продолжить";
                flag = false;
                timer.Stop();
               
            }
            
        }

        private void Stop_button_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            Start_button.IsEnabled = true;
        }

    }
}
