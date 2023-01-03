using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L4U_API_SOAP.SoapModels
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

        public User()
        { }


        public User(object obj)
        { }

        //fazer data row?


    }
}