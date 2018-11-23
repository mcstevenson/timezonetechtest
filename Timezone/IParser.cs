namespace Timezone
{
    /// <summary>
    /// Parses the data and displays as a string
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Displays the time string.
        /// </summary>
        /// <param name="zone">The zone.</param>
        void DisplayTime(TimezoneConverter zone);
    }
}
