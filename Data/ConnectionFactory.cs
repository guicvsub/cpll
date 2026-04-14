using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace cpll.Data
{
    internal class ConnectionFactory
    {
        private readonly DbConfig _config;

        public ConnectionFactory()
        {
            _config = new DbConfig();
        }

        public MySqlConnection CreateConnection()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = _config.Server,
                Database = _config.Database,
                UserID = _config.User,
                Password = _config.Password,
                Port = _config.Port
            };

            return new MySqlConnection(builder.ConnectionString);
        }
    }
}
