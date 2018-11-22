using System;
using System.Collections.Generic;

using Serilog;

namespace Timezone
{
    class Program
    {        
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\Timezone.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Parser timeZoneParser = new Parser();
            using (Reader fileReader = new Reader())
            {
                List<Tuple<string, string>> lTimes = fileReader.Read();
                foreach (var time in lTimes)
                {
                    timeZoneParser.DisplayTime(time.Item1, time.Item2);
                }
            }
        }
    }
}
