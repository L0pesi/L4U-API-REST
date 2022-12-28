namespace L4U_DAL_DATA.Utils
{
    public class ConfigData
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string ConnString { get => $"Server = {Server}; Database = {Database}; User ID = {Username}; Password = {Password}; Trusted_Connection = False; Pooling = False;"; }

        public ConfigData()
        {
            this.Server = "DESKTOP-P4T9S96\\SQLEXPRESS";
            this.Database = "l4u";
            this.Username = "sa";
            this.Password = "1234";
        }

        /*public ConfigData()
        {
            this.Server = @"l4userver.database.windows.net";
            this.Database = "L4U-DB";
            this.Username = "supergrupoadmin";
            this.Password = "supergrupo+2022";
        }*/

        public string GetConnectionString() => ConnString;




    }
}
