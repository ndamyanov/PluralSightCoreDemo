using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralSightCoreDemo.Services
{
    public interface IGreater
    {
        string GetMessageOfTheDay();
    }

    public class Greeter : IGreater
    {
        private IConfiguration _config;
        public Greeter(IConfiguration configuration)
        {
            this._config = configuration;
        }
        public string GetMessageOfTheDay()
        {
            return this._config["Greeting"];
        }
    }
}
