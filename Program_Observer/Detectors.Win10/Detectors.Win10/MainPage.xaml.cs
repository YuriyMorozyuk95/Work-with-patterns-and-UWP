using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



namespace Detectors.Win10
{

    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private MapSecurity _mapSecurity;
        public MapSecurity MapSecurity
        {
            get { return _mapSecurity; }
            set
            {
                _mapSecurity = value;
                OnPropertyChanged("MapSecurity");
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

        public MainPage()
        {
            this.InitializeComponent();
            MapSecurity = new MapSecurity(Correcting1, Correcting2);
            DataContext = this;
        }


        private void Start_button_Click(object sender, RoutedEventArgs e)
        {
            MapSecurity.StartTimer();
            End_button.IsEnabled = true;
            Start_button.IsEnabled = false;
           
            DispetcherSwitch1.IsEnabled = false;
            DispetcherSwitch2.IsEnabled = false;

        }

        private void End_button_Click(object sender, RoutedEventArgs e)
        {
            MapSecurity.StopTimer();
            Start_button.IsEnabled = true;
            End_button.IsEnabled = false;
            DispetcherSwitch1.IsEnabled = true;
            DispetcherSwitch2.IsEnabled = true;
            MapSecurity = new MapSecurity(Correcting1, Correcting2);
            MapSecurity.EnableMonitorSensor(DispetcherSwitch2.IsOn);
            MapSecurity.EnableDetectorTemp(DispetcherSwitch1.IsOn);

        }

        private void DispetcherSwitch2_Toggled(object sender, RoutedEventArgs e)
        {
            MapSecurity.EnableMonitorSensor(DispetcherSwitch2.IsOn);
        }

        private void DispetcherSwitch1_Toggled(object sender, RoutedEventArgs e)
        {
            MapSecurity.EnableDetectorTemp(DispetcherSwitch1.IsOn);
        }
    }
}
