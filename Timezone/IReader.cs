namespace Timezone
{
    using System.Collections.Generic;

    /// <summary>
    /// Reads from the source file.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Reads from the source file.
        /// </summary>
        /// <returns>Returns <see cref="List{TimezoneConverter}<"/></returns>
        List<TimezoneConverter> Read();
    }
}
