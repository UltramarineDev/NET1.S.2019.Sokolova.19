using System;
using System.Globalization;

namespace StringExtension
{
    /// <summary>
    /// CustomFormatProvider class
    /// </summary>
    /// <seealso cref="System.IFormatProvider" />
    /// <seealso cref="System.ICustomFormatter" />
    public class CustomFormatProvider : IFormatProvider, ICustomFormatter
    {
        IFormatProvider parentProvider;

        public CustomFormatProvider() : this(CultureInfo.CurrentCulture) { }
        public CustomFormatProvider(IFormatProvider parent)
        {
            parentProvider = parent;
        }

        /// <summary>
        /// Converts the value of a specified object to an equivalent string representation using specified format and culture-specific formatting information.
        /// </summary>
        /// <param name="format">A format string containing formatting specifications.</param>
        /// <param name="arg">An object to format.</param>
        /// <param name="formatProvider">An object that supplies format information about the current instance.</param>
        /// <returns>
        /// The string representation of the value of <paramref name="arg" />, formatted as specified by <paramref name="format" /> and <paramref name="formatProvider" />.
        /// </returns>
        /// <exception cref="FormatException"></exception>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null || format != "TE")
            {
                return string.Format(parentProvider, "{0:" + format + "}", arg);
            }

            if (arg is Book)
            {
                return ((Book)arg).Title + ", " + ((Book)arg).Year;
            }

            throw new FormatException(String.Format("The format of '{0}' is invalid.", format));
        }

        /// <summary>
        /// Returns an object that provides formatting services for the specified type.
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return.</param>
        /// <returns>
        /// An instance of the object specified by <paramref name="formatType" />, if the <see cref="T:System.IFormatProvider" /> implementation can supply that type of object; otherwise, <see langword="null" />.
        /// </returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }
    }
}
