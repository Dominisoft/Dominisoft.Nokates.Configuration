using Dominisoft.Nokates.Common.Infrastructure.Attributes;
using Dominisoft.Nokates.Common.Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc;
using file = System.IO.File;

namespace Dominisoft.Nokates.Configuration.Controllers
{
    [Route("")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        [HttpGet("{applicationName}")]
        [EndpointGroup("ConfigurationRead")]
        [NoAuth]
        public string GetConfigByApplicationName(string applicationName)
        {
            ConfigurationValues.TryGetValue(out var configDir, "ConfigurationDirectory");
            var filePath = $"{configDir}/{applicationName}.json";
            if (file.Exists(filePath))
            {
                var template = file.ReadAllText(filePath);
                return ConfigurationTransformHelper.ReplaceStaticValues(template); 
            }
            return "{}";
        }
    }
}
