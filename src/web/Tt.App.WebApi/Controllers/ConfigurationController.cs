using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Tt.App.WebApi.Configuration;
using Tt.App.WebApi.Services;

namespace Tt.App.WebApi.Controllers
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
            return notificationConfiguration.EnableEmailNotification;
        }

        [HttpGet("[action]")]
        public ActionResult<DateTime> GetCurrentUtcTime()
        {
            logger.LogInformation("Log before return utc time :)");
            return utcTimeService.CurrentUtcDateTime;
        }
    }
}