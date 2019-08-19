using System;

namespace Tt.AspNetCoreWebApi.Services
{
    public interface ITimeService
    {
        DateTime CurrentTime { get; }
    }

    public interface IUtcTimeService
    {
        DateTime CurrentUtcDateTime { get; }
    }

    public class TimeService : ITimeService, IUtcTimeService
    {
        public DateTime CurrentTime => DateTime.Now;

        public DateTime CurrentUtcDateTime => DateTime.UtcNow;
    }
}