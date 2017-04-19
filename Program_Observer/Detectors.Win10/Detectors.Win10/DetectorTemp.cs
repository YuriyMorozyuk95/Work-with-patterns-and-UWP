using System;
using System.ComponentModel;

namespace Detectors.Win10
{
    public class DetectorTemp : IObserver
    {
        private String _message;
        public String Message
        {
            get
            {
                return _message;
            }

            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public void Update(ISubject subject)
        {
            var room = subject as Room;
            if (room.T > 100)
                Message = "Небезпечна температура включається охолоджувач";
            else
                Message = "Безпечно";
        }
    }

}

