using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4U_BOL_MODEL.Models
{
    internal class Lockers
    {
        public string Id { get; set; }
        public int InputCode { get; set; } //penso que aqui seja public int invés de public string
        public string Name { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }

        public Lockers() { }
        public Lockers(DataRow dr)
        {
            this.Id = dr["id"].ToString();
            this.InputCode = int.Parse(dr["inputCode"].ToString());
            this.Name = dr["name"].ToString();
            this.Adress = dr["adress"].ToString();
            this.ZipCode = dr["zipCode"].ToString();

        }
    }
}
