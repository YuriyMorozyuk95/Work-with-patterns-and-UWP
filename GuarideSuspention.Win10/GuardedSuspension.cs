using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using System.Windows;
using Windows.UI;
using Windows.UI.Core;

namespace GuarideSuspention.Win10
{
    class GuardedSuspension 
    {
        Queue _queue;
        FactoryPerson _factory;        
        bool _pushIsCompleted;
        bool _pullIsCompleted;
        Task _pushTask;
        Task<Person> _pullTask;
        AutoResetEvent _resultWaiting;
        public static bool Sensor { get; set; }
        public static TimeSpan TimeForPull { get; set; }
        public static TimeSpan TimeForPush { get; set; }
         private void startPull()
        {
            _pullTask = new Task<Person>(()=> Pull());
             _pullTask.Start();
        }
        private void startPush()
        {
            _pushTask = new Task(() => Push(_factory.GetPerson()));
            _pushTask.Start();
        }
        public void Push(Person person)
        {           
            _pushIsCompleted = false;
            Task.Delay(TimeForPush).Wait();
            _resultWaiting.Set();
            _pushIsCompleted = true;
            _queue.Push(person);
        }
        public Person Result()
        {
            _resultWaiting.WaitOne();
            Sensor = true;
            return _pullTask.Result;
        }
        private void WaitT()
        {
            Task.Delay(TimeForPull).Wait();
        }
        private void Wait()
        {
            
            if (_pushTask == null)
            {
                startPush();      
                Task.WaitAny(_pushTask);
            }
            else
                Task.WaitAny(_pushTask);
        }
        public Person Pull()
        {
            Sensor = false;
            Task.Delay(TimeForPull).Wait();

            _pullIsCompleted = false;
            if (isEmpty())
            {
                Wait();
            }
            
            
            _pullIsCompleted = true;
            return _queue.Pull();
        }
        private bool isEmpty()
        {
            if (_queue.Count < 1)
                return true;
            else
                return false;
        }
        //color
        public static SolidColorBrush brushRed { get; set; }
        public static SolidColorBrush brushGreen { get; set; }
        public GuardedSuspension(Queue queue, FactoryPerson factory)
        {
            _queue = queue;
            _factory = factory;
            _resultWaiting = new AutoResetEvent(false);
            
            startPull();
            startPush();
        }
        public bool StartNew()
        {
            if (Counter == 0)
                return true;
            if (_pullIsCompleted && _pushIsCompleted)
                return true;
            else
            {
                Task.WaitAll(_pushTask, _pullTask);
                return true;
            }
        }
        public static int Counter { get; set; }
    }
}
