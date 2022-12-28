using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace L4U_BOL_MODEL.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string City { get; set; }


        public string Password { get; set; }

        public string Token { get; set; } = string.Empty;


        //fazer data row?


    }
}
