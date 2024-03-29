﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4U_BOL_MODEL.Models
{
    public class Locker
    {
        public string Id { get; set; } //Locker id
        public string StoreId { get; set; }
        public string UserId { get; set; }

        public string PinCode { get; set; }

        public string MasterCode { get; set; }

        public string LockerType { get; set; }

        public bool LockerStatus { get; set; }


        //public List<Locker> lockers { get; set; } = null;


        public Locker() { }
        public Locker(object obj)
        { }

        public bool IsLockerValid()
        {
            if (string.IsNullOrEmpty(this.PinCode)) return false;
            if (string.IsNullOrEmpty(this.StoreId)) return false;
            if (string.IsNullOrEmpty(this.UserId)) return false;
            if (string.IsNullOrEmpty(this.LockerType)) return false;

            return true;
        }

    }
}
