using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebAdvert.ElasticSearch
{
    public static class Configurationhelper
    {
        private static IConfiguration _configuration = null;

        public static IConfiguration Instance
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
                }
                return _configuration;


            }
        }
    }
}
