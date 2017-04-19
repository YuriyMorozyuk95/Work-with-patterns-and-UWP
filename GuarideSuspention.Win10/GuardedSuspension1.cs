using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuarideSuspention.Win10
{
    class GuardedSuspension : INotifyProperyChanged
    {
        Queue _queue;
        FactoryPerson _factory;

        bool _pushIsCompleted;
        bool _pullIsCompleted;
        Task _pushTask;
        Task<Person> _pullTask;
        AutoResetEvent _resultWaiting;
        public static TimeSpan TimeForPull { get; set; }
        public static TimeSpan TimeForPush { get; set; }
        private void startPull()
        {
            _pullTask = new Task<Person>(() => Pull());
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
            return _pullTask.Result;
        }
        private void Wait()
        {
            Console.Write("Wait");
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
            _pullIsCompleted = false;
            Task.Delay(TimeForPull).Wait();

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
            if (_pullIsCompleted && _pushIsCompleted)
                return true;
            else
            {
                Task.WaitAll(_pushTask, _pullTask);
                return true;
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
    }
}
