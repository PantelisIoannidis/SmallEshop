using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallEshop.Web.Services
{
    public class ConfigurationVariables : IConfigurationVariables
    {
        private IConfiguration configuration;
        public ConfigurationVariables(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string ImagesPath
        {
            get
            {
                return configuration["ImagesPath"];
            }
        }
    }
}
