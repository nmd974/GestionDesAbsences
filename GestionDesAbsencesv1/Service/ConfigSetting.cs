using Microsoft.Extensions.Configuration;
using System.IO;

namespace GestionDesAbsencesv1.ViewModels
{
    class ConfigSetting
    {
        ConfigurationBuilder _builder = new();
        IConfigurationRoot _configuration;
        public ConfigSetting(string settingFile)
        {
            _builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(settingFile, optional: false, reloadOnChange: true);
            _configuration = _builder.Build();
        }

        public IConfiguration Configuration
        {
            get
            {
                return _configuration;
            }
        }

        public string GetConnection(string name)
        {
            return _configuration.GetConnectionString(name);
        }

        public string getConfig(string section, string key)
        {

            return _configuration.GetSection(section).GetRequiredSection(key).Value;
        }
    }
}
