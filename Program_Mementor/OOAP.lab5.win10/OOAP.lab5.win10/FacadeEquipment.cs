using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace OOAP.lab5.win10
{
    //[DataContract]
    public class FacadeEquipment: INotifyPropertyChanged
    {
        //[DataMember]
        private ObservableCollection<Character> _wariors;
        //[DataMember]
        public ObservableCollection<Character> Wariors
        {
            get
            {
                return _wariors;
            }
            set
            {
                _wariors = value;
                OnPropertyChanged("Wariors");
            }
        }

        private Character _warior;

        public Character Warior
        {
            get
            {
                return _warior;
            }
            set
            {
                _warior = value;
                OnPropertyChanged("Warior");
            }
        }
        public void SetWarior(int i)
        {
            _warior = Wariors[i];
        }
        public FacadeEquipment()
        {
            Wariors = FactoryCharacter.Create();
        }
        public void AddClothes(Clothes clothes)
        {
            var equip = new EquipClothes(_warior);
            switch((int)clothes)
            {
                case 0:
                    equip.UnEquip();
                    break;
                case 1:
                    equip.EquipIronClothes();
                    break;
                case 2:
                    equip.EquipMeralClothes();
                    break;
            }
        }
        public void AddShield(Shield shield)
        {
            var equip = new EquipShield(_warior);
            switch ((int)shield)
            {
                case 0:
                    equip.UnEquip();
                    break;
                case 1:
                    equip.EquipIronShield();
                    break;
                case 2:
                    equip.EquipMeralShield();
                    break;
            }
        }
        public void AddArsenal(Arsenal arsenal)
        {
            var equip = new EquipArsenal(_warior);
            switch ((int)arsenal)
            {
                case 0:
                    equip.UnEquip();
                    break;
                case 1:
                    equip.EquipDanger();
                    break;
                case 2:
                    equip.EquipBow();
                    break;
                case 3:
                    equip.EquipMace();
                    break;
                case 4:
                    equip.EquipSword();
                    break;
                case 5:
                    equip.EquipAx();
                    break;
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
    static class FactoryCharacter
    {
        public static ObservableCollection<Character> Create()
        {
            ObservableCollection<Character> factory = new ObservableCollection<Character>();
            
            factory.Add(new Skeleton());
            factory.Add(new Human());
            factory.Add(new Troll());
            factory.Add(new Elf());
            factory.Add(new Orc());
            factory.Add(new Naga());
            factory.Add(new Deamon());
            return factory;

        }
    }
}
