using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detectors.Win10
{
    public interface IObserver: INotifyPropertyChanged
    {
        void Update(ISubject subject);
        String Message { get; set; }
         
    }
}
