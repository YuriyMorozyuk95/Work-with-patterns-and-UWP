using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Detectors.Win10
{
    public class MonitorSensor : IObserver
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
        public void Update(ISubject subject)
        {
            var room = subject as Room;
            if (room.Movement)
                Message = "Замічений порушник , починаю знешкодження";
            else
                Message = "Безпечно";
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
