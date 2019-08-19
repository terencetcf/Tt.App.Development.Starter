﻿namespace Tt.AspNetCoreWebApi.Configuration
{
    public interface INotificationConfiguration
    {
        bool EnableEmailNotification { get; set; }
    }

    public class NotificationConfiguration : INotificationConfiguration
    {
        public bool EnableEmailNotification { get; set; }
    }
}
