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

        public string Server => _config["server"] ?? "localhost";
        public string Database => _config["database"] ?? string.Empty;
        public string User => _config["user"] ?? string.Empty;
        public string Password => _config["password"] ?? string.Empty;
        public uint Port
        {
            get
            {
                string? portValue = _config["port"] ?? _config["Port"];
                return uint.TryParse(portValue, out uint port) ? port : 3306;
            }
        }
    }
}
