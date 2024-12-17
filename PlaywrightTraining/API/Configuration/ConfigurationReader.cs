using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAutomationFramework.API.Configuration
{
    public class ConfigurationReader
    {
        private readonly IConfigurationRoot _configuration;

        public ConfigurationReader(string configFileName = "appsettings.json")
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configFileName, optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        public string GetSetting(string key)
        {
            return _configuration[key];
        }

        public T GetSection<T>(string sectionName)
        {
            return _configuration.GetSection(sectionName).Get<T>();
        }

        public Settings GetSettings()
        {
            return _configuration.Get<Settings>();
        }
    }
}
