using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;
using System.Runtime.Serialization.Json;
using System.Reflection;
using System.Collections.ObjectModel;

namespace OOAP.lab5.win10
{
    class MementoGame
    {
        readonly private FacadeEquipment _state;
        public MementoGame(FacadeEquipment state)
        {
            _state = new FacadeEquipment()
            {
                Wariors = new ObservableCollection<Character>(state.Wariors.Select(item => item.Clone()).ToList())
            };
        }
        public FacadeEquipment GetState()
        {
            return _state;
        }
        
    }
}
