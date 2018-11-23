namespace Timezone
{
    using System.Collections.Generic;

    using Serilog;

    /// <summary>
    /// Timezone application. Used to display converted timezone information.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\Timezone.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Application started");

            Parser timeZoneParser = new Parser();
            using (Reader fileReader = new Reader())
            {
                List<TimezoneConverter> lTimes = fileReader.Read();
                foreach (var time in lTimes)
                {
                    timeZoneParser.DisplayTime(time);
                }
            }
        }
    }
}
