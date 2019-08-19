using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tt.AspNetCoreWebApi.Configuration;
using Tt.AspNetCoreWebApi.Services;

namespace Tt.AspNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly INotificationConfiguration notificationConfiguration;
        private readonly IUtcTimeService utcTimeService;
        private readonly ILogger<ConfigurationController> logger;


        public ConfigurationController(INotificationConfiguration notificationConfiguration, IUtcTimeService utcTimeService, ILogger<ConfigurationController> logger)
        {
            this.notificationConfiguration = notificationConfiguration;
            this.utcTimeService = utcTimeService;
            this.logger = logger;
        }

        [HttpGet("[action]")]
        public ActionResult<bool> IsEmailNotificationEnabled()
        {
            return Ok(notificationConfiguration.EnableEmailNotification);
        }

        [HttpGet("[action]")]
        public ActionResult<bool> GetCurrentUtcTime()
        {
            logger.LogInformation("Log before return utc time :)");
            return Ok(utcTimeService.CurrentUtcDateTime);
        }
    }
}