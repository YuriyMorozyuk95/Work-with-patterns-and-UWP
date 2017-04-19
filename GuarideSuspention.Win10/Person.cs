using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.ComponentModel;
using Windows.UI.Popups;

namespace GuarideSuspention.Win10
{
    class Person:INotifyPropertyChanged
    {
        public String FullName { get; set; }
        String _name;
        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        String _surname;
        public String Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public Person(String fullName)
        {
            FullName = fullName;
        }
        public void CreateName()
        {
            var fullName = FullName.Split(' ');
            this.Name = fullName[0];
            this.Surname = fullName[1];
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(String NameProperty)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(NameProperty));
        }
        public override string ToString()
        {
            return FullName + " ";
        }
    }
    class FactoryPerson
    {
        List<Person> _personTemplate;
        List<int> _repeat;
        static int rendnum;
        public int count;
        public FactoryPerson()
        {
            _personTemplate = new List<Person>();
            _repeat = new List<int>();
            _personTemplate.Add(new Person("Валерій Харчишин"));
            _personTemplate.Add(new Person("Дмитрий Кузнецов"));
            _personTemplate.Add(new Person("Аліна Тодирюк"));
            _personTemplate.Add(new Person("Вікторія Лящук"));
            _personTemplate.Add(new Person("Марія Котвінська"));
            _personTemplate.Add(new Person("Яна Вірмянська"));
            _personTemplate.Add(new Person("Рома Марковський"));
            _personTemplate.Add(new Person("Марія Кравець"));
            _personTemplate.Add(new Person("Викторія Федорова"));
            _personTemplate.Add(new Person("Ілля Булгаков"));
            _personTemplate.Add(new Person("Денис Грещук"));
            _personTemplate.Add(new Person("Настя Ващук"));
            _personTemplate.Add(new Person("Юлія Демьянская"));
            _personTemplate.Add(new Person("Анастасия Залєвська"));
            _personTemplate.Add(new Person("Софія Назарова"));
            _personTemplate.Add(new Person("Ігор Лазаревич"));
            _personTemplate.Add(new Person("Наталія Гулева"));
            _personTemplate.Add(new Person("Марія Боднар"));
            _personTemplate.Add(new Person("Іра Нехін"));
            _personTemplate.Add(new Person("Назар Притула"));
            _personTemplate.Add(new Person("Олександр Волошин"));
            _personTemplate.Add(new Person("Христя Надич"));
            _personTemplate.Add(new Person("Надя Чийпеш"));
            _personTemplate.Add(new Person("Вікторія Гончарук"));
            _personTemplate.Add(new Person("Ярослав Квітневий"));
            _personTemplate.Add(new Person("Микола Новак"));
            _personTemplate.Add(new Person("Оля Вільхова"));
            _personTemplate.Add(new Person("Міша Малярчинець"));
            _personTemplate.Add(new Person("Бодя Стадник"));
            _personTemplate.Add(new Person("Микола Віхоть"));
            foreach (Person person in _personTemplate)
                person.CreateName();
            count = _personTemplate.Count;
        }
        private int getRendomIndex() //получення індекса який ще небув задіяний
        {
            int index;
            if (_repeat.Count == 0)
            {
                rendnum = 1;
                index = new Random(DateTime.Now.Millisecond - rendnum).Next(0, count);
                _repeat.Add(index);
                rendnum++;
                return index;
            }
            else
                while (true)
                {
                    index = new Random(DateTime.Now.Millisecond - rendnum).Next(0, count);
                    bool notRepeat = false;
                    foreach (int i in _repeat)
                        if (index==i)
                        {
                            notRepeat = true;
                        }
                    if(!notRepeat)
                    {
                        _repeat.Add(index);
                        rendnum++;
                        return index;
                    }
                }
        }
        public Person GetPerson()
        {
            return _personTemplate[getRendomIndex()];
        }
    }
}
