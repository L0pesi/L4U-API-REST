namespace L4U_BOL_MODEL.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        // string UserName { get; set; }
        //public string City { get; set; }

        //public List<User> users { get; set; } = null;

        public string Password { get; set; }

        public string Token { get; set; } = string.Empty;

        //public List<User> users { get; set; } = null;

        public User()
        { }



        /*public User(string id)
        {
            this.Id = id;
        }*/

        public User(object obj)
        {
            this.Id = obj.ToString();

        }



        //fazer data row?

        public bool IsValid()
        {
            //if (string.IsNullOrEmpty(this.UserName)) return false;
            if (string.IsNullOrEmpty(this.Password)) return false;
            if (string.IsNullOrEmpty(this.FirstName)) return false;
            if (string.IsNullOrEmpty(this.LastName)) return false;
            if (string.IsNullOrEmpty(this.Email)) return false;
            //if (string.IsNullOrEmpty(this.City)) return false;

            return true;
        }

    }
}
