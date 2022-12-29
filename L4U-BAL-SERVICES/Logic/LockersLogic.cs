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
    public class LockersLogic
    {

        private readonly LockerService _lockerService;

        public LockersLogic()
        {
            _lockerService = new LockerService();
        }

        public List<Locker> GetLockers
        {
            get
            {
                return _lockerService.GetLockers();
            }
        }



        public void AddLocker(Locker locker)
        {
            _lockerService.AddLocker(locker);
        }


    }
}