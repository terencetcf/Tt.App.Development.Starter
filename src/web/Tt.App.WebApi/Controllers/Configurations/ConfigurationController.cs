﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Tt.App.WebApi.Configuration;
using Tt.App.Services;

namespace Tt.App.WebApi.Controllers.Configurations
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class ConfigurationController : ApiControllerBase
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

        [ApiVersion("2.0")]
        [HttpOptions("[action]")]
        public IActionResult ClearCache()
        {
            return Accepted();
        }
    }
}