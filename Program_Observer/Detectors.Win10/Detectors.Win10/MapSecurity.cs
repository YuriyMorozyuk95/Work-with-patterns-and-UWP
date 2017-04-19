using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Detectors.Win10
{
   public class MapSecurity : INotifyPropertyChanged
    {
        bool timerStoped;
        public MapSecurity(ProgressBar correcting1, ProgressBar correcting2)
        {
            Room = new Room();
            Room.Detectors = new List<IObserver>();
            DetectorTemp = new DetectorTemp();
            MonitorSensor = new MonitorSensor();
            this.correcting1 = correcting1;
            this.correcting2 = correcting2;
            _timer = new DispatcherTimer();
            MonitorSensor.Message = "Безпечно";
            DetectorTemp.Message = "Безпечно";
        }

        // work to room
        public DetectorTemp DetectorTemp { get; }
        public MonitorSensor MonitorSensor { get; }


        public void EnableDetectorTemp(bool enable)
        {
            if (enable)
                Room.AttachObserver(DetectorTemp);
            else
               Room.DetachObserver(DetectorTemp);
        }
        public void EnableMonitorSensor(bool enable)
        {
            if (enable)
                 Room.AttachObserver(MonitorSensor);
            else
                Room.DetachObserver(MonitorSensor);
        }
        private Room _room;
        public Room Room
        {
            get
            {
                return _room;
            }
            set
            {
                _room = value;
                OnPropertyChanged("Room");
            }
        }

        //work to timer
        private DispatcherTimer _timer;
        private ProgressBar correcting1;
        private ProgressBar correcting2;

        public void StartTimer()
        {
            _timer.Tick += _timer_Tick;
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Start();
             timerStoped = false;
        }
        public void StopTimer()
        {
            _timer.Stop();
            timerStoped = true;
        }

       async private void _timer_Tick(object sender, object e)
        {
                Room.Iteration();
            if (DetectorTemp.Message == "Небезпечна температура включається охолоджувач") 
                {
                    _timer.Stop();
                    var _progTimer1 = new DispatcherTimer();
                    _progTimer1.Interval = TimeSpan.FromMilliseconds(250);
                    _progTimer1.Tick += Timer_Tick1;
                    correcting1.Value = 0;
                    correcting1.Minimum = 0;
                    correcting1.Maximum = 10;
                    _progTimer1.Start();
                    
                    await Task.Delay(3000);
                    _progTimer1.Stop();
                    DetectorTemp.Message = "Безпечно";
                    Room.T = 30;
                    if (!timerStoped && MonitorSensor.Message == "Безпечно" && DetectorTemp.Message == "Безпечно")
                        _timer.Start();
                }
                if (MonitorSensor.Message == "Замічений порушник , починаю знешкодження")
                {
                    _timer.Stop();
                    var _progTimer2 = new DispatcherTimer();
                    _progTimer2.Interval = TimeSpan.FromMilliseconds(250);
                    _progTimer2.Tick += Timer_Tick2;
                    correcting2.Value = 0;
                    correcting2.Minimum = 0;
                    correcting2.Maximum = 14;
                    _progTimer2.Start();
                    
                    await Task.Delay(4000);
                    _progTimer2.Stop();
                    MonitorSensor.Message = "Безпечно";
                    Room.Movement = false;
                    if (!timerStoped && MonitorSensor.Message == "Безпечно" && DetectorTemp.Message == "Безпечно")
                        _timer.Start();
            }
            
        }
        private void Timer_Tick1(object sender, object e)
        {
           // DetectorTemp.Message = "Небезпечна температура включається охолоджувач";
            correcting1.Value++;
        }
        private void Timer_Tick2(object sender, object e)
        {
           //MonitorSensor.Message = "Замічений порушник , починаю знешкодження";
            correcting2.Value++;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}