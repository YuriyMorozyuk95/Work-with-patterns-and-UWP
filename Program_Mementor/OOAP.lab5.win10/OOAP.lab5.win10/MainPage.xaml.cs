using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OOAP.lab5.win10
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
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
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            Character.BaseUri = ListWariors.BaseUri;
            DataContext = this;
            Wariors = Global.OperationWariors.Wariors;
        }

        /// <summary>
        /// Вызывается перед отображением этой страницы во фрейме.
        /// </summary>
        /// <param name="e">Данные события, описывающие, каким образом была достигнута эта страница.
        /// Этот параметр обычно используется для настройки страницы.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ListWariors.SelectedIndex = -1;
            
            Wariors = Global.OperationWariors.Wariors;
            // TODO: Подготовьте здесь страницу для отображения.

            // TODO: Если приложение содержит несколько страниц, обеспечьте
            // обработку нажатия аппаратной кнопки "Назад", выполнив регистрацию на
            // событие Windows.Phone.UI.Input.HardwareButtons.BackPressed.
            // Если вы используете NavigationHelper, предоставляемый некоторыми шаблонами,
            // данное событие обрабатывается для вас.
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ListWariors.SelectedIndex != -1)
                Frame.Navigate(typeof(BlankPage1), ListWariors.SelectedIndex);
            else
                (new MessageDialog("Виберіть персонажа")).ShowAsync();
        }

        private void buttle_Click(object sender, RoutedEventArgs e)
        {
            if (ListWariors.SelectedIndex != -1)
                Frame.Navigate(typeof(Battle), ListWariors.SelectedIndex);
            else
                (new MessageDialog("Виберіть персонажа")).ShowAsync();
        }

        private void Heal_Click(object sender, RoutedEventArgs e)
        {
            if (ListWariors.SelectedIndex != -1)
                Wariors[ListWariors.SelectedIndex].Health = 100;
            else
                (new MessageDialog("Виберіть персонажа")).ShowAsync();
        }
        MementoGame memento;
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Global.OperationWariors.Wariors = Wariors;
            memento = new MementoGame(Global.OperationWariors);
            //memento.SaveGame();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //memento.LoadGame();
                Global.LoadGame(memento.GetState());
                Wariors = Global.OperationWariors.Wariors;
            }
            catch(Exception)
            {
                (new MessageDialog("Не вдалося завантажити збереження")).ShowAsync();
            }
        }
    }
}
