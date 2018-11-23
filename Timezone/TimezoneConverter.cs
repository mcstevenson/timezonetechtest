using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    public class TimezoneConverter
    {
        public TimezoneConverter(string time, string timezone)
        {
            if (string.IsNullOrWhiteSpace(time))
            {
                throw new ArgumentException("Time cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(timezone))
            {
                throw new ArgumentException("Timezone cannot be null or empty.");
            }

            TimeSpan tSpan = TimeSpan.Parse(time);

            //var uTCZone = TimeZoneInfo.GetSystemTimeZones().SingleOrDefault(t => t.DisplayName.Contains("London"));
            var uTcTime = DateTime.Today.Add(tSpan).ToUniversalTime();            
            var destZone = TimeZoneInfo.GetSystemTimeZones().SingleOrDefault(t => t.DisplayName.Contains(timezone));

            if (destZone == null)
            {
                throw new Exception($"The registry does not define a timezone that contains {timezone}.");
            }

            this.UtcTime = uTcTime;
            this.ConvertedTime = TimeZoneInfo.ConvertTime(uTcTime, TimeZoneInfo.Utc, destZone);
            this.Timezone = timezone;
        }

        public DateTime UtcTime { get; }

        public DateTime ConvertedTime { get; }

        public string Timezone { get; }
    }
}
