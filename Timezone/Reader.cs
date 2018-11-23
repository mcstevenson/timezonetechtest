namespace Timezone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Serilog;

    using Timezone.Properties;

    /// <summary>
    /// The Reader class. Used to read the data from the source file.
    /// </summary>
    /// <seealso cref="Timezone.IReader" />
    /// <seealso cref="System.IDisposable" />
    public class Reader : IReader, IDisposable
    {
        /// <summary>
        /// Reads the data from the source file
        /// </summary>
        /// <returns>Returns a list of <see cref="TimezoneConverter"/></returns>
        public List<TimezoneConverter> Read()
        {
            List<TimezoneConverter> timeZones = new List<TimezoneConverter>();

            var resource = Resources.ResourceManager.GetObject("Timezone");

            if (resource == null)
            {
                // the resource file could not be found 
                Log.Error("Unable to access Timezone.txt");
            }

            if (string.IsNullOrWhiteSpace(resource.ToString()))
            {
                // the resource file is empty
                Log.Error("The resource file Timezone.txt is empty.");
            }

            string[] fileParts = Resources.Timezone.Split( new[] { "\r\n", "\r", "\n" },  StringSplitOptions.RemoveEmptyEntries);


            if (fileParts.Length > 1)
            {
                foreach (string part in fileParts)
                {
                    string[] elements = part.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // validate the time element
                    TimeSpan tSpan;
                    var success = TimeSpan.TryParse(elements[0], out tSpan);

                    if (!success)
                    {
                        Log.Error($"Unable to parse the time for timezone: {elements[1]}");
                        continue;
                    }

                    // validate the timezone element
                    var destZone = TimeZoneInfo.GetSystemTimeZones().SingleOrDefault(z => z.DisplayName.Contains(elements[1]));

                    if (destZone == null)
                    {
                        Log.Error($"The registry does not define a timezone that contains {elements[1]}.");
                        continue;
                    }

                    var timeZoneConverter = new TimezoneConverter(elements[0], elements[1]);
                    timeZones.Add(new TimezoneConverter(elements[0], elements[1]));
                } 
            }

            return timeZones;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
