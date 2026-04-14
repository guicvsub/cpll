using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;


namespace cpll.Data
{
    internal class DbConfig
    {
        private readonly IConfiguration _config;

        public DbConfig()
        {
            _config = new ConfigurationBuilder()
                .AddUserSecrets<DbConfig>()
                .Build();
        }

        public string Server => "localhost";
        public string Database => _config["database"] ?? string.Empty;
        public string User => _config["user"] ?? string.Empty;
        public string Password => _config["password"] ?? string.Empty;
        public uint Port => uint.Parse(_config["Port"] ?? "3306");
    }
}
