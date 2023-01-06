using Newtonsoft.Json;
using System.Data;

namespace L4U_BOL_MODEL.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public bool isActive { get; set; }
        // string UserName { get; set; }
        //public string City { get; set; }

        //public List<User> users { get; set; } = null;

        [JsonIgnore]
        public string Password { get; set; }

        public string Token { get; set; } = string.Empty;

        //public List<User> users { get; set; } = null;

        public User()
        { }


        public User(object obj)
        {
            this.Id = obj.ToString();

        }

        public User(DataRow dr)
        {
            this.Id = dr["id"].ToString();
            this.FirstName = dr["firstName"].ToString();
            this.LastName = dr["lastName"].ToString();
            this.Email = dr["email"].ToString();
            this.Password = dr["password"].ToString();
        }

        public bool IsValid()
        {

            if (string.IsNullOrEmpty(this.FirstName)) return false;
            if (string.IsNullOrEmpty(this.LastName)) return false;
            if (string.IsNullOrEmpty(this.Email)) return false;
            if (string.IsNullOrEmpty(this.Password)) return false;

            return true;
        }

    }
}
