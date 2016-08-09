using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLiteReader
{
    class LoginModel
    {
        public string ActionUrl { get; set; }

        public string SiteUrl { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public LoginModel(string actionUrl, string siteUrl, string loginName, string password)
        {
            ActionUrl = actionUrl;
            SiteUrl = siteUrl;
            LoginName = loginName;
            Password = password;
        }

        public string GetLoginsString()
        {
            return "ActionUrl: " + ActionUrl + 
                "; SiteUrl: " + SiteUrl + 
                "; Login: " + LoginName + 
                "; Password: " + Password + " \r\n";
        }
    }
}
