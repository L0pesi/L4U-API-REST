using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using L4U_BOL_MODEL.Models;
using L4U_DAL_DATA.Services;

namespace L4U_BAL_SERVICES.Logic
{
    public class StoresLogic
    {
        private readonly StoresService _storeService;

        public StoresLogic()
        {

            _storeService = new StoresService();

        }

        public List<Store> GetAll
        {
            get
            {
                return _storeService.GetAllStores();
            }
        }



        public void AddStores(Store store)
        {
            _storeService.AddStore(store);
        }
    }
}

