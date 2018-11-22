using System;
using System.Collections.Generic;
using System.Linq;

using Serilog;

using Timezone.Properties;

namespace Timezone
{
    class Reader : IReader, IDisposable
    {
        public List<Tuple<string, string>> Read()
        {
            List<Tuple<string, string>> lReturn = new List<Tuple<string, string>>();

            var resource = Resources.ResourceManager.GetObject("Timezone");

            if (resource == null)
            {
                Log.Error("Unable to access Timezone.txt");
                throw new NullReferenceException("The resource file Timezone.txt has been removed or is unavailable.");
            }

            if (string.IsNullOrWhiteSpace(resource.ToString()))
            {
                Log.Error("The resource file Timezone.txt is empty.");
                throw new Exception("The resource file Timezone.txt is empty. Please close the application and update the file.");
            }

            string[] fileParts = Resources.Timezone.Split( new[] { "\r\n", "\r", "\n" },  StringSplitOptions.RemoveEmptyEntries); 
            

            foreach (string part in fileParts)
            {               
                string[] sLineParts = part.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                TimeSpan timespan;

                var success = TimeSpan.TryParse(sLineParts[1], out timespan);

                if (!success)
                {
                    // log the error and move to the next line
                    Log.Debug($"Unable to parse the time for {sLineParts[1]}");
                    continue;
                }

                var tZone = TimeZoneInfo.GetSystemTimeZones().Where(t => t.DisplayName.Contains(sLineParts[1]));


                Tuple<string, string> timeZone = new Tuple<string, string>(sLineParts.First(), sLineParts.Last());

                lReturn.Add(timeZone);
            }

            return lReturn;
        }
        public void Dispose()
        {
        }
    }
}
