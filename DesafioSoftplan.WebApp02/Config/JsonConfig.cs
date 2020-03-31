using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSoftplan.WebApp02.Config
{
    public class JsonConfig
    {
        private static IConfigurationRoot builderConfig => new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile($"appsettings.json")
                    .Build();
        public static string GetSectionConfig(string key)
        {
            return builderConfig.GetSection(key).Value;
        }
    }
}
