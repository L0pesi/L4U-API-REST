﻿namespace L4U_BOL_MODEL.Models
{
    public class Stores
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Name { get; set; }
        public List<Stores> Store { get; set; } = null; //lista de cacifos


    }
}