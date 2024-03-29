﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4U_DAL_DATA.Utilities
{

    /// <summary>
    /// General Configuration of Connection String v1
    /// </summary>
    public class conectionString
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string connectString { get => $"Server = {Server}; Database = {Database}; User ID = {Username}; Password = {Password}; Trusted_Connection = False; Pooling = False;"; }

        public conectionString()
        {
            this.Server = @"l4u.database.windows.net";
            this.Database = "L4U";
            this.Username = "supergrupoadmin";
            this.Password = "supergrupo+2022";
        }

    }
}
