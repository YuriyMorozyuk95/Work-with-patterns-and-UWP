using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace OOAP.lab5.win10
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Battle : Page, INotifyPropertyChanged
    {
        private Character _you;
        public Character You
        {
            get { return _you; }
            set
            {
                _you = value;
                OnPropertyChanged("You");
            }
        }
        private Character _enemy;
        public Character Enemy
        {
            get { return _enemy; }
            set
            {
                _enemy = value;
                OnPropertyChanged("Enemy");
            }
        }
        private ObservableCollection<Character> _wariors;
        public ObservableCollection<Character> Wariors
        {
            get { return _wariors; }
            set
            {
                _wariors = value;
                OnPropertyChanged("Wariors");
            }
        }
        public Battle()
        {
            this.InitializeComponent();
            DataContext = this;
            
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            You = Global.OperationWariors.Wariors[(int)e.Parameter];
            Wariors = new ObservableCollection<Character>();
            foreach (Character Warior in Global.OperationWariors.Wariors)
                Wariors.Add(Warior);
            Wariors.Remove(You);

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

        private void ChangeEnemy_Click(object sender, RoutedEventArgs e)
        {
            Enemy = Wariors[ListWariors.SelectedIndex];
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Global.OperationWariors.Wariors = new ObservableCollection<Character>();
            if (You.Health > 0)
                Wariors.Add(You);
            foreach (Character Warior in Wariors)
            {
                if(Warior.Health>0) 
                    Global.OperationWariors.Wariors.Add(Warior);
            }
            Frame.GoBack();

        }

          private void AttackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Enemy != null)
            {
                Fight = new Fight(You, Enemy,Wariors);
                Fight.Battle();
            }
            else
                (new MessageDialog("Виберіть супротивника")).ShowAsync();

        }


        private Fight _fight;
        public Fight Fight
        {
            get
            {
                return _fight;
            }
            set
            {
                _fight = value;
                OnPropertyChanged("Fight");
            }
        }

        private void RandomEnemy_Click(object sender, RoutedEventArgs e)
        {
            var rnd = new Random();
            Enemy = Wariors[rnd.Next(0,Wariors.Count)];
        }
    }
}
