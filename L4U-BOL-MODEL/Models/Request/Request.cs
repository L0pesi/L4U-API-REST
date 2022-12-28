using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4U_BOL_MODEL.Models.Request
{
    public class RequestModel
    {
        public string Uid { get; set; } = string.Empty;   //by default
        public DateTime? Since { get; set; }
        public DateTime? Until { get; set; }
        public object GenericObject { get; set; } = null;
    }
}
