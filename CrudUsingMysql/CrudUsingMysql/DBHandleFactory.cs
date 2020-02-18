using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CrudUsingMysql
{
    public class DBHandleFactory
    {
        private ConnectionStringSettings connectionStringSettings;

        public DBHandleFactory(string connectionStringName)
        {
            connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
        }

         IDBSwitch CreateDatabase()
        {
            IDBSwitch database = null;

            switch (connectionStringSettings.ProviderName.ToLower())
            {
                case "system.data.sqlclient":
                    database = new SqlServerDataAccess(connectionStringSettings.ConnectionString);
                    break;
                case "MySql.Data.MySqlClient":
                    database = new MySqlDataAccess(connectionStringSettings.ConnectionString);
                    break;
            }
            return database;
        }

        public string GetProviderName()
        {
            return connectionStringSettings.ProviderName;
        }
    }
}