namespace L4U_BOL_MODEL.Models
{
    public class Store
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Name { get; set; }
        public List<Store> Stores { get; set; } = null; //lista de cacifos


    }
}
