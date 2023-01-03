using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4U_BOL_MODEL.Models
{
    public class UserAuth
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public UserAuth()
        {

        }

        public UserAuth(DataRow dr)
        {
            this.Email = dr["email"].ToString();
            this.Password = dr["password"].ToString();
        }
    }
}
