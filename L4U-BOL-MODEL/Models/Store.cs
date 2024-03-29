﻿namespace L4U_BOL_MODEL.Models
{
    public class Store
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Name { get; set; }
        public bool StoreStatus { get; set; }

        // public List<Store> Stores { get; set; } = null; //lista de cacifos

        public Store()
        { }

        public Store(object obj)
        { }

        public bool IsStoreValid()
        {
            if (string.IsNullOrEmpty(this.Address)) return false;
            if (string.IsNullOrEmpty(this.City)) return false;
            if (string.IsNullOrEmpty(this.District)) return false;
            if (string.IsNullOrEmpty(this.Name)) return false;

            return true;
        }
    }
}
