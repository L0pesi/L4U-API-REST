using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace L4U_DAL_DATA.Utilities
{
    public class EmailSender
    {

        public static SmtpClient GetSmtpClient()
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(config.GetSection("EmailCredentials:Email").Value.ToString(), config.GetSection("EmailCredentials:Password").Value.ToString());

            smtpClient.EnableSsl = true;

            return smtpClient;
        }

    }
}
