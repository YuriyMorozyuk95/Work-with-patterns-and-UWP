using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detectors.Win10
{
    public interface ISubject:INotifyPropertyChanged
    {
        void AttachObserver(IObserver observer);
        void DetachObserver(IObserver observer);
        void Notifi();
    }
}
