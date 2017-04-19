using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;

namespace OOAP.lab5.win10
{
    abstract class Equipment: Character
    {
        protected MessageDialog upEquip = new MessageDialog("Спочатку зніміть інвентар");
        public Character Сharacter;
        public abstract void UnEquip();
    }
    class EquipClothes : Equipment
    {
        public EquipClothes(Character Character)
        {
            
            this.Сharacter = Character;
            if(Сharacter.ImgClothes==null)
            Сharacter.ImgClothes = new BitmapImage();
        }
        public void EquipIronClothes()
        {
            if (Сharacter.Clothes == Clothes.none)
            {
                Сharacter.Clothes = Clothes.IronArmor;
                Сharacter.ImgClothes.UriSource = new Uri(Character.BaseUri, "Icon/IronArmor.jpg");
                Сharacter.Armor += 5;
            }
            else
                upEquip.ShowAsync();
        }
        public void EquipMeralClothes()
        {
            if (Сharacter.Clothes == Clothes.none)
            {
                Сharacter.Clothes = Clothes.MetalArmor;
                Сharacter.ImgClothes.UriSource = new Uri(Character.BaseUri, "Icon/MetalArmor.jpg");
                Сharacter.Armor += 10;
            }
            else
                upEquip.ShowAsync();
        }
        public override void UnEquip()
        {
            if (Сharacter.Clothes!=Clothes.none)
            {
                switch ((int)Сharacter.Clothes)
                {
                    case 1:
                        Сharacter.Armor -= 5;
                        break;
                    case 2:
                        Сharacter.Armor -= 10;
                        break;
                }
            }

            Сharacter.Clothes = Clothes.none;
            Сharacter.ImgClothes.UriSource = new Uri(Character.BaseUri, "Icon/void.jpg");
        }
    }
    class EquipShield : Equipment
    {
        public EquipShield(Character Character)
        {
            
            this.Сharacter = Character;
            if (Сharacter.ImgShield == null)
                Сharacter.ImgShield = new BitmapImage();
        }
        public void EquipIronShield()
        {
            if (Сharacter.Shield == Shield.none)
            {
                Сharacter.Shield = Shield.IronShield;
                Сharacter.ImgShield.UriSource = new Uri(Character.BaseUri, "Icon/IronShield.jpg");
                Сharacter.Armor += 3;
            }
            else        
                upEquip.ShowAsync();
            
        }
        public void EquipMeralShield()
        {
            if (Сharacter.Shield == Shield.none)
            {
                Сharacter.Shield = Shield.MetalShield;
                Сharacter.ImgShield.UriSource = new Uri(Character.BaseUri, "Icon/MetalShield.jpg");
                Сharacter.Armor += 5;
            }
            else
            {
                upEquip.ShowAsync();
            }
        }
        public override void UnEquip()
        {

            if (Сharacter.Shield != Shield.none)
            {
                switch ((int)Сharacter.Shield)
                {
                    case 1:
                        Сharacter.Armor -= 3;

                        break;
                    case 2:
                        Сharacter.Armor -= 5;
                        break;
                }

                
            }
            Сharacter.Shield = Shield.none;
            Сharacter.ImgShield.UriSource = new Uri(Character.BaseUri, "Icon/void.jpg");
        }
    }
    class EquipArsenal : Equipment
    {
        public EquipArsenal(Character Character)
        {

            this.Сharacter = Character;
            if (Сharacter.ImgArsenal == null)
                Сharacter.ImgArsenal = new BitmapImage();
        }
        public void EquipDanger()
        {
            if (Сharacter.Arsenal == Arsenal.none)
            {
                Сharacter.Arsenal = Arsenal.Dagger;
                Сharacter.ImgArsenal.UriSource = new Uri(Character.BaseUri, "Icon/Danger.jpg");
                Сharacter.Strenght += 5;
            }
            else
                upEquip.ShowAsync();
        }
        public void EquipBow()
        {
            if (Сharacter.Arsenal == Arsenal.none)
            {
                Сharacter.Arsenal = Arsenal.Bow;
                Сharacter.ImgArsenal.UriSource = new Uri(Character.BaseUri, "Icon/Bow.jpg");
                Сharacter.Strenght += 10;
            }
            else
                upEquip.ShowAsync(); 
        }
        public void EquipMace()
        {
            if (Сharacter.Arsenal == Arsenal.none)
            {
                Сharacter.Arsenal = Arsenal.Mace;
                Сharacter.ImgArsenal.UriSource = new Uri(Character.BaseUri, "Icon/Mace.jpg");
                Сharacter.Strenght += 15;
            }
            else
                upEquip.ShowAsync();
        }
        public void EquipSword()
        {
            if (Сharacter.Arsenal == Arsenal.none)
            {
                Сharacter.Arsenal = Arsenal.Sword;
                Сharacter.ImgArsenal.UriSource = new Uri(Character.BaseUri, "Icon/swoard.jpg");
                Сharacter.Strenght += 20;
            }
            else
                upEquip.ShowAsync();
        }
        public void EquipAx()
        {
            if (Сharacter.Arsenal == Arsenal.none)
            {
                Сharacter.Arsenal = Arsenal.Ax;
                Сharacter.ImgArsenal.UriSource = new Uri(Character.BaseUri, "Icon/Ax.jpg");
                Сharacter.Strenght += 25;
            }
            else
                upEquip.ShowAsync();
        }
        public override void UnEquip()
        {
            if (Сharacter.Arsenal != Arsenal.none)
            {
                switch ((int)Сharacter.Arsenal)
                {
                    case 1:
                        Сharacter.Strenght -= 5;
                        break;
                    case 2:
                        Сharacter.Strenght -= 10;
                        break;
                    case 3:
                        Сharacter.Strenght -= 15;
                        break;
                    case 4:
                        Сharacter.Strenght -= 20;
                        break;
                    case 5:
                        Сharacter.Strenght -= 25;
                        break;
                }

               
            }
            Сharacter.Arsenal = Arsenal.none;
            Сharacter.ImgArsenal.UriSource = new Uri(Character.BaseUri, "Icon/void.jpg");
        }
    }
}
