using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAP.lab5.win10
{
    static class Global
    {

        private static FacadeEquipment _operationWariors;
        public static FacadeEquipment OperationWariors
        {
            get
            {
                return _operationWariors ?? (_operationWariors = new FacadeEquipment());
            }
        }
        public static void LoadGame(FacadeEquipment load)
        {
            _operationWariors = load;
        }
    }
}
