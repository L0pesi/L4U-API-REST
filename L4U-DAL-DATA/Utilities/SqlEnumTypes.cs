﻿using L4U_DAL_DATA.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4U_DAL_DATA.Utilities
{
    /// <summary>
    /// This enum lists the possible sql requests that can be made
    /// (for stProcd)
    /// </summary>
    public enum SqlEnumTypes
    {
        GetSingle = 1,
        GetList = 2,
        Insert = 3,
        Update = 4,
        Delete = 5
    }
}
