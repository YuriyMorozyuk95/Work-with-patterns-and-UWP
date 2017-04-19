using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detectors.Win10
{
    public class Room :ISubject
    {
        public static int Numbers { get; set; }

        private int _number;
        public int Number
        {
            get
            {
                return _number;
            }
            private set
            {
                _number = value;
                OnPropertyChanged("Number");
            }
        }

        public static List<IObserver> Detectors; 
        public Room()
        {
            Time = new TimeSpan(0,0,0,0);
            T = 0;
            Numbers++;
            Number = Numbers;
        }

        private int _t;
        public int T
        {
            get
            {
                return _t;
            }
            set
            {
                _t = value;
                OnPropertyChanged("T");
            }
        }

        public bool Movement { get; set; }
        private TimeSpan _time;
        public TimeSpan Time { get
            {
                return _time;
            }
            private set
            {
                _time = value;
                OnPropertyChanged("Time");
            }
        }
        public void Iteration() 
        {
            Time += TimeSpan.FromMinutes(5);
            T = (new Random(DateTime.Now.Millisecond - Number)).Next(0, 120);
            Movement = ((new Random(DateTime.Now.Millisecond - Number)).Next(0, 10) == 4);
            Notifi();
        }
        public void AttachObserver(IObserver observer)
        {
            Detectors.Add(observer);
        }
        public void DetachObserver(IObserver observer)
        {
            Detectors.Remove(observer);
        }
        public void Notifi()
        {
            foreach (IObserver detector in Detectors)
                detector.Update(this);
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
