using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Meetup.Security.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ConfigController : Controller
    {
        public ConfigController(IConfigurationRoot config)
        {
            Config = config;
        }

        private IConfigurationRoot Config { get; set; }        

        // GET: api/values
        [HttpGet]        
        public object Get()
        {            
            var valueFromConfig = new
            {
                Environment = Config["environment"]         
            };

            return valueFromConfig;            
        }
    }
}
