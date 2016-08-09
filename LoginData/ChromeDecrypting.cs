using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using SQLiteReader.ChromePasswordRecover;

namespace SQLiteReader
{
    class ChromeDecrypting
    {
        private const string DataProviderName = "System.Data.SQLite";

        private const string Connection = "Data Source={0};Version=3;FailIfMissing=True";

        private static readonly CryptoAPI crypto = new CryptoAPI();

        public const string QueryChrome = "SELECT `origin_url`	as OriginalUrl, " +
               "`signon_realm` as SignUrl, " +
               "`username_value`	as usernameValue, " +
               "`password_value`	passwordValue From logins";

        private const string dataFileRelativePath = "Google\\Chrome\\User Data\\Default\\Login Data";

        public static string GetDefaultChromePasswordFile()
        {
            string appDataRoot = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(appDataRoot, dataFileRelativePath);
        }

        public string GetConnectionString()
        {
            return String.Format(Connection, GetDefaultChromePasswordFile());
        }

        public List<LoginModel> GetLogins()
        {
            List<LoginModel> logins = new List<LoginModel>();
            SQLiteData sqLite = new SQLiteData(DataProviderName, GetConnectionString());
            

               var reader = sqLite.GetReader(QueryChrome);
               while (reader.Read())
               {
                   var passwordBuffer = reader.GetValue(3) as byte[];
                   var password = crypto.DecryptString(passwordBuffer);
                   logins.Add(new LoginModel(reader.GetString(0), reader.GetString(1), reader.GetString(2), password));
               }
               reader.Close();



            return logins;
        }
    }
}
