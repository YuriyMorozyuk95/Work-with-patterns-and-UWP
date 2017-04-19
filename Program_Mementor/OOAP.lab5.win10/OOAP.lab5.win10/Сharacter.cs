using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace OOAP.lab5.win10
{

    public enum Clothes
    { none, IronArmor, MetalArmor }
    public enum Shield
    { none, IronShield, MetalShield }
    public enum Arsenal
    { none, Dagger, Bow, Mace, Sword, Ax }
    [DataContract]
    public class Character : INotifyPropertyChanged
    {
        public Character()
        {
            Icon = new BitmapImage();
            Clothes = Clothes.none;
            Shield = Shield.none;
            Arsenal = Arsenal.none;
        }
        [DataMember]
        public static Uri BaseUri { get; set; }
        [DataMember]
        private String _name;
        [DataMember]
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        [DataMember]
        protected int? _health;
        [DataMember]
        protected int? _strenght;
        [DataMember]
        protected int? _armor;
        [DataMember]
        public int? Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
                if (_health < 0)
                    _health = 0;
                OnPropertyChanged("Health");
            }
        }
        [DataMember]
        public int? Strenght
        {
            get { return _strenght; }
            set
            {
                _strenght = value;
                OnPropertyChanged("Strenght");
            }
        }
        [DataMember]
        public int? Armor
        {
            get { return _armor; }
            set
            {
                _armor = value;
                OnPropertyChanged("Armor");
            }
        }
        [DataMember]
        protected String _strClothes;
        [DataMember]
        protected String _strShield;
        [DataMember]
        protected String _strArsenal;
        [DataMember]
        public String StrClothes
        {
            get { return _strClothes; }
            set
            {
                _strClothes = value;
                OnPropertyChanged("StrClothes");
            }
        }
        [DataMember]
        public String StrShield
        {
            get
            { return _strShield; }
            set
            {
                _strShield = value;
                OnPropertyChanged("StrShield");
            }
        }
        [DataMember]
        public String StrArsenal
        {
            get { return _strArsenal; }
            set
            {
                _strArsenal = value;
                OnPropertyChanged("StrArsenal");
            }
        }

        [DataMember]
        protected BitmapImage _imgClothes;
        [DataMember]
        protected String _imgClothesUri;

        [DataMember]
        protected BitmapImage _imgShield;
        [DataMember]
        protected String _imgShieldUri;

        [DataMember]
        protected BitmapImage _imgArsenal;
        [DataMember]
        protected String _imgArsenalUri;

        [DataMember]
        public BitmapImage ImgClothes
        {
            get { return _imgClothes; }
            set
            {
                _imgClothes = value;
                OnPropertyChanged("ImgClothes");
            }
        }
        [DataMember]
        public BitmapImage ImgShield
        {
            get { return _imgShield; }
            set
            {
                _imgShield = value;
                OnPropertyChanged("ImgShield");
            }
        }
        [DataMember]
        public BitmapImage ImgArsenal
        {
            get { return _imgArsenal; }
            set
            {
                _imgArsenal = value;
                OnPropertyChanged("ImgArsenal");
            }
        }
        [DataMember]
        protected Clothes _clothes;
        [DataMember]
        protected Shield _shield;
        [DataMember]
        protected Arsenal _arsenal;
        [DataMember]
        public Clothes Clothes
        {
            get
            {
                return _clothes;
            }
            set
            {
                switch ((int)value)
                {
                    case 0:
                        StrClothes = "немає";
                        _clothes = value;
                        return;
                    case 1:
                        StrClothes = "Зелізна броня";
                        break;
                    case 2:
                        StrClothes = "Сталева броня";
                        break;
                }
                _clothes = value;
            }
        }
        [DataMember]
        public Shield Shield
        {
            get
            {
                return _shield;
            }
            set
            {
                switch ((int)value)
                {
                    case 0:
                        StrShield = "немає";
                        _shield = value;
                        return;
                    case 1:
                        StrShield = "Залізний щит";
                        break;
                    case 2:
                        StrShield = "Сталевий щит";
                        break;
                }
                _shield = value;
            }
        }
        [DataMember]
        public Arsenal Arsenal
        {
            get
            {
                return _arsenal;
            }
            set
            {
                switch ((int)value)
                {
                    case 0:
                        StrArsenal = "немає";
                        _arsenal = value;
                        return;
                    case 1:
                        StrArsenal = "Кинжал";
                        break;
                    case 2:
                        StrArsenal = "Лук";
                        break;
                    case 3:
                        StrArsenal = "Булава";
                        break;
                    case 4:
                        StrArsenal = "Меч";
                        break;
                    case 5:
                        StrArsenal = "Сокира";
                        break;
                }
                _arsenal = value;
            }
        }
        [DataMember]
        protected BitmapImage _icon;
        [DataMember]
        public BitmapImage Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged("Icon");
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
        public Character Clone()
        {
            var clon = new Character()
            {
                Name = this.Name,
                Armor = this.Armor,
                Health = this.Health,
                Strenght = this.Strenght,
                Icon = this.Icon,
                Clothes = this.Clothes,
                Shield = this.Shield,
                Arsenal = this.Arsenal,
                ImgClothes = this.ImgClothes,
                ImgShield = this.ImgShield,
                ImgArsenal = this.ImgArsenal
            };
            return clon;
        }

    }
    [DataContract]
    class Human : Character
    {
        public Human() : base()
        {
            Name = "Людина";
            Health = 100;
            Armor = 0;
            Strenght = 10;
            Icon.UriSource = new Uri(BaseUri, "Icon/humen_ico.jpg");

        }
    }
    [DataContract]
    class Troll : Character
    {
        public Troll() : base()
        {
            Name = "Троль";
            Health = 100;
            Armor = 0;
            Strenght = 15;
            Icon.UriSource = new Uri(BaseUri, "Icon/troll_ico.jpg");
        }
    }
    [DataContract]
    class Orc : Character
    {
        public Orc() : base()
        {
            Name = "Орк";
            Health = 100;
            Armor = 0;
            Strenght = 20;
            Icon.UriSource = new Uri(BaseUri, "Icon/orc_ico.jpg");
        }
    }
    [DataContract]
    class Skeleton : Character
    {
        public Skeleton() : base()
        {
            Name = "Скилет";
            Health = 100;
            Armor = 0;
            Strenght = 7;
            Icon.UriSource = new Uri(BaseUri, "Icon/Skilet_Ico.jpg");
        }
    }
    [DataContract]
    class Elf : Character
    {
        public Elf() : base()
        {
            Name = "Ельф";
            Health = 100;
            Armor = 0;
            Strenght = 17;
            Icon.UriSource = new Uri(BaseUri, "Icon/Elf_Ico.jpg");
        }
    }
    [DataContract]
    class Naga : Character
    {
        public Naga() : base()
        {
            Name = "Нага";
            Health = 100;
            Armor = 0;
            Strenght = 25;
            Icon.UriSource = new Uri(BaseUri, "Icon/Naga_Ico.jpg");
        }
    }
    [DataContract]
    class Deamon : Character
    {
        public Deamon() : base()
        {
            Name = "Демон";
            Health = 100;
            Armor = 0;
            Strenght = 30;
            Icon.UriSource = new Uri(BaseUri, "Icon/Deamon_Ico.jpg");
        }
    }
}
