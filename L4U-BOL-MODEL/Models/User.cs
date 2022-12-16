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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }

        [JsonIgnore]//não sei se devemos ignorar a password e o token
        public string Password { get; set; }

        public string Token { get; set; } = string.Empty;

        public User()
        { }

        public User(object obj)
        { }

        public User(DataRow dr)
        {
            this.Id = dr["id"].ToString();
            this.FirstName = dr["firstName"].ToString();
            this.LastName = dr["lastName"].ToString();
            this.Email = dr["email"].ToString();
            this.UserName = dr["userName"].ToString();
            this.PhoneNumber = dr["phoneNumber"].ToString();
            this.City = dr["city"].ToString();
            this.Password = dr["userPassword"].ToString();
            //eles ja tinha o public string token em baixo do [JsonIgnore] então nao alterei, mas não sei se tenho de o colocar aqui
        }
    }
}
