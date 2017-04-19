using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace OOAP.lab5.win10
{
    public class Fight: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private int _stroke;
        public int Stroke
        {
            get
            {
                return _stroke;
            }
            set
            {
                _stroke = value;
                OnPropertyChanged("Stroke");
            }
        }
        private Character _at, _df;
        private ObservableCollection<Character> wariors;

        public Fight(Character at, Character df)
        {
            Stroke = 0;
            _at = at;
            _df = df;
        }

        public Fight(Character at, Character df, ObservableCollection<Character> wariors) : this(at, df)
        {
            this.wariors = wariors;
        }

        private void Attack()
        {

            _df.Health -= _at.Strenght;

            
        }
        private void Replace()
        {
            Character tmp = _at;
            _at = _df;
            _df = tmp;

        }
        private bool WhoIsWiner()
        {
            Character winer;
            if (_at.Health <= 0)
            {
                winer = _df;
                (new MessageDialog(String.Format("{0} Переміг!", winer.Name))).ShowAsync();
                wariors.Remove(_at);  
                return true;
            }
            if (_at.Health <= 0)
            {
                winer = _at;
                (new MessageDialog(String.Format("{0} Переміг!", winer.Name))).ShowAsync();
                wariors.Remove(_df);
                return true;
            }
            return false;
        }
        public async void Battle()
        {
            Attack();
            Replace();
            await Task.Delay(1000);
            Stroke++;
            if (!WhoIsWiner())
                Battle();
        }

    }
}
