using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace L4U_BOL_MODEL.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public DateTime DateOfCreation { get; set; }
        public string Token { get; set; } = string.Empty;

        public User()
        { }

        public User(object obj)
        { }
        asdasasdasd
        public User(DataRow dr)
        {
            this.Id = dr["id"].ToString();
            this.Name = dr["name"].ToString();
            this.Email = dr["email"].ToString();
            this.Username = dr["username"].ToString();
            this.Password = dr["password"].ToString();
            this.DateOfCreation = DateTime.Parse(dr["dateOfCreation"].ToString());
        }
    }
}
