using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//teste fetch
namespace L4U_BOL_MODEL.Models
{
    internal class Packages
    {
        public string Id { get; set; }
        public string Adress { get; set; }
        public string PostalCode { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public int IdentifierCode { get; set; } //alterei para public int

        public Packages() { }
        public Packages(DataRow dr)
        {
            this.Id = dr["id"].ToString();
            this.Adress = dr["adress"].ToString();
            this.PostalCode = dr["postalCode"].ToString();
            this.District = dr["district"].ToString();
            this.City = dr["city"].ToString();
            this.Name = dr["name"].ToString();
            this.IdentifierCode = int.Parse(dr["identifierCode"].ToString());

        }


    }
}

