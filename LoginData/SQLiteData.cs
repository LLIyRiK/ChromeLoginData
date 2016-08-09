using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Text;


namespace SQLiteReader
{
    internal class SQLiteData
    {
        private readonly string dataProviderName;
        private readonly string sqLiteConnectionString;

        public SQLiteData(string dataProviderName, string sqLiteConnectionString)
        {
            this.dataProviderName = dataProviderName;
            this.sqLiteConnectionString = sqLiteConnectionString;
        }

        public DbDataReader GetReader(string query)
        {
            var conn = OpenConnection();
            var command = conn.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = query;
            return command.ExecuteReader();
        }

        private DbConnection OpenConnection()
        {
            DbProviderFactory fact = DbProviderFactories.GetFactory(dataProviderName);
            DbConnection cnn = fact.CreateConnection();
            cnn.ConnectionString = sqLiteConnectionString;
            cnn.Open();
            return cnn;
        }
    }
}
