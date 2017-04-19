using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace OOAP.lab5.win10
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class BlankPage1 : Page,INotifyPropertyChanged
    {
        BitmapImage _imgArmor;
        String _nameArmor;
        BitmapImage _imgShield;
        String _nameShield;
        BitmapImage _imgArsenal;
        String _nameArsenal;

        public BitmapImage ImgArmor
        {
            get
            {
                return _imgArmor;
            }
            set
            {
                _imgArmor = value;
                OnPropertyChanged("ImgArmor");
            }
        }
        public String NameArmor
        {
            get { return _nameArmor; }
            set { _nameArmor = value;
                OnPropertyChanged("NameArmor");
            }
        }

        public BitmapImage ImgShield
        { get { return _imgShield; }
            set
            {
                _imgShield = value;
                OnPropertyChanged("ImgShield");
            }
        }
        public String NameShield
        {
            get
            {
                return _nameShield;
            }
            set
            {
                _nameShield = value;
                OnPropertyChanged("NameShield");
            }
        }
        public BitmapImage ImgArsenal
        {
            get
            {
                return _imgArsenal;
            }
            set
            {
                _imgArsenal = value;
                OnPropertyChanged("ImgArsenal");
            }
        }
        public String NameArsenal
        {
            get { return _nameArsenal; }
            set { _nameArsenal = value;
                OnPropertyChanged("NameArsenal");
            }
        }
     

        public void SetTovar()
        {
            DataContext = this;
            ImgArmor = Global.OperationWariors.Warior.ImgClothes;
            NameArmor = Global.OperationWariors.Warior.StrClothes;

            ImgShield = Global.OperationWariors.Warior.ImgShield;
            NameShield = Global.OperationWariors.Warior.StrShield;

            ImgArsenal = Global.OperationWariors.Warior.ImgArsenal;
            NameArsenal = Global.OperationWariors.Warior.StrArsenal;

        }


        public int index;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public BlankPage1()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            index = (int)e.Parameter;
            Global.OperationWariors.SetWarior(index);
            SetTovar();
            switch (index)
            {
                case 0:
                    СharacterName.Text = "Вдягніть людину";
                    break;
                case 1:
                    СharacterName.Text = "Вдягніть троля";
                    break;
                case 2:
                    СharacterName.Text = "Вдягніть орка";
                    break;
            }
            if (Global.OperationWariors.Warior.Clothes == Clothes.none)
                UnEqupArn_Click(new object(),new RoutedEventArgs());
            if (Global.OperationWariors.Warior.Shield == Shield.none)
                UnEqupSh_Click(new object(), new RoutedEventArgs());
            if (Global.OperationWariors.Warior.Arsenal == Arsenal.none)
                UnEqupArs_Click(new object(), new RoutedEventArgs());
        }

        private void UnEqupArn_Click(object sender, RoutedEventArgs e)
        {
            Global.OperationWariors.AddClothes(Clothes.none);
            ImgArmor = Global.OperationWariors.Warior.ImgClothes;
            NameArmor = Global.OperationWariors.Warior.StrClothes;
        }

        private void UnEqupSh_Click(object sender, RoutedEventArgs e)
        {
            Global.OperationWariors.AddShield(Shield.none);
            ImgShield = Global.OperationWariors.Warior.ImgShield;
            NameShield = Global.OperationWariors.Warior.StrShield;
        }

        private void UnEqupArs_Click(object sender, RoutedEventArgs e)
        {
            Global.OperationWariors.AddArsenal(Arsenal.none);
            ImgArsenal = Global.OperationWariors.Warior.ImgArsenal;
            NameArsenal = Global.OperationWariors.Warior.StrArsenal;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();

        }

        private void EqupArmIron_Click(object sender, RoutedEventArgs e)
        {
            Global.OperationWariors.AddClothes(Clothes.IronArmor);
            ImgArmor = Global.OperationWariors.Warior.ImgClothes;
            NameArmor = Global.OperationWariors.Warior.StrClothes;

        }

        private void EqupArmMetal_Click(object sender, RoutedEventArgs e)
        {
            Global.OperationWariors.AddClothes(Clothes.MetalArmor);
            ImgArmor = Global.OperationWariors.Warior.ImgClothes;
            NameArmor = Global.OperationWariors.Warior.StrClothes;
        }

        private void EqupShldIron_Click(object sender, RoutedEventArgs e)
        {
            Global.OperationWariors.AddShield(Shield.IronShield);
            ImgShield = Global.OperationWariors.Warior.ImgShield;
            NameShield = Global.OperationWariors.Warior.StrShield;
        }

        private void EqupShldMetal_Click(object sender, RoutedEventArgs e)
        {
            Global.OperationWariors.AddShield(Shield.MetalShield);
            ImgShield = Global.OperationWariors.Warior.ImgShield;
            NameShield = Global.OperationWariors.Warior.StrShield;
        }

        private void EqupArsDanger_Click(object sender, RoutedEventArgs e)
        {
            Global.OperationWariors.AddArsenal(Arsenal.Dagger);
            ImgArsenal = Global.OperationWariors.Warior.ImgArsenal;
            NameArsenal = Global.OperationWariors.Warior.StrArsenal;
        }

        private void EqupArsBow_Click(object sender, RoutedEventArgs e)
        {
            Global.OperationWariors.AddArsenal(Arsenal.Bow);
            ImgArsenal = Global.OperationWariors.Warior.ImgArsenal;
            NameArsenal = Global.OperationWariors.Warior.StrArsenal;
        }

        private void EqupArsMace_Click(object sender, RoutedEventArgs e)
        {
            Global.OperationWariors.AddArsenal(Arsenal.Mace);
            ImgArsenal = Global.OperationWariors.Warior.ImgArsenal;
            NameArsenal = Global.OperationWariors.Warior.StrArsenal;
        }

        private void EqupArsSwoard_Click(object sender, RoutedEventArgs e)
        {
            Global.OperationWariors.AddArsenal(Arsenal.Sword);
            ImgArsenal = Global.OperationWariors.Warior.ImgArsenal;
            NameArsenal = Global.OperationWariors.Warior.StrArsenal;
        }

        private void EqupArsAx_Click(object sender, RoutedEventArgs e)
        {
            Global.OperationWariors.AddArsenal(Arsenal.Ax);
            ImgArsenal = Global.OperationWariors.Warior.ImgArsenal;
            NameArsenal = Global.OperationWariors.Warior.StrArsenal;
        }
    }
}
