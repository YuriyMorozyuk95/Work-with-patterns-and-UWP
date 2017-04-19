using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GuarideSuspention.Win10
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        GuardedSuspension Iteration;
        SolidColorBrush brushRed, brushGreen;
        FactoryPerson factory;
        Queue queue;
        public MainPage()
        {
            this.InitializeComponent();
            brushRed = new SolidColorBrush();
            brushRed.Color = Color.FromArgb(255, 255, 0, 0);
            brushGreen = new SolidColorBrush();
            brushGreen.Color = Color.FromArgb(255, 0, 255, 0);

        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            factory = new FactoryPerson();
            queue = new Queue();
            GuardedSuspension.TimeForPull = TimeSpan.FromMilliseconds(Convert.ToInt32(Queue.Text));
            GuardedSuspension.TimeForPush = TimeSpan.FromMilliseconds(Convert.ToInt32(newClient.Text));
            GuardedSuspension.Counter = 0;
            timer1 = new DispatcherTimer()
            {
                Interval = TimeSpan.FromMilliseconds(50)
            };
            timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromMilliseconds(50)
            };
            timerRed = new DispatcherTimer()
            {
                Interval = GuardedSuspension.TimeForPull
            };
            timerGreen = new DispatcherTimer()
            {
                Interval = GuardedSuspension.TimeForPush
            };
            Iteration = new GuardedSuspension(queue, factory);
            List.Items.Clear();
            timer1.Tick += Timer1_Tick;
            timer.Tick += Timer_Tick;
            timerRed.Tick += TimerRed_Tick;
            timerGreen.Tick += TimerGreen_Tick;
            timer1.Start();
            timer.Start();
            timerRed.Start();
            timerGreen.Start();
        }
        private void TimerGreen_Tick(object sender, object e)
        {
            Wait.Fill = brushGreen;
        }

        private void TimerRed_Tick(object sender, object e)
        {
             if(GuardedSuspension.TimeForPull<GuardedSuspension.TimeForPush)
            Wait.Fill = brushRed;
        }

        DispatcherTimer timer, timer1, timerRed, timerGreen;
        private void Timer1_Tick(object sender, object e)
        {
            if(Iteration.StartNew()){ 
                Iteration = new GuardedSuspension(queue, factory);
                List.Items.Add(Iteration.Result().ToString());
                GuardedSuspension.Counter++;
            }
            if (GuardedSuspension.Counter == 29)
                (sender as DispatcherTimer).Stop();
        }
        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timer1.Stop();
            timerGreen.Stop();
            timerRed.Stop();
        }
        private void Timer_Tick(object sender, object e)
        {        
            //if (Sensor)
            //    Wait.Fill = brushGreen;
            //else
            //    Wait.Fill = brushRed;
        }
    }
}
