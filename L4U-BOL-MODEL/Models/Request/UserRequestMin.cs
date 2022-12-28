using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4U_BOL_MODEL.Models.Request
{
    public class UserRequestMin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Team { get; set; }
    }
}
