namespace Timezone
{
    using System;

    /// <summary>
    /// Parses the TimezoneConverter and displays the time string
    /// </summary>
    /// <seealso cref="Timezone.IParser" />
    public class Parser : IParser
    {
        /// <summary>
        /// Displays the time string.
        /// </summary>
        /// <param name="zone">The zone.</param>
        public void DisplayTime(TimezoneConverter zone)
        {
            Console.WriteLine($"The time in the UK is {zone.UtcTime.ToString("h:mm tt")}. The time in {zone.Timezone} is {zone.ConvertedTime.ToString("h:mm tt")}");       
        }
    }
}
