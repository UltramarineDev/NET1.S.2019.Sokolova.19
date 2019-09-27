using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace StringExtension
{
    /// <summary>
    /// DoubleProvider class
    /// </summary>
    /// <seealso cref="System.IFormatProvider" />
    /// <seealso cref="System.ICustomFormatter" />
    public class DoubleProvider : IFormatProvider, ICustomFormatter
    {
        IFormatProvider parentProvider;

        public DoubleProvider() : this(CultureInfo.CurrentCulture) { }
        public DoubleProvider(IFormatProvider parent)
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
            if (arg == null || format != "IEEE")
            {
                return string.Format(parentProvider, "{0:" + format + "}", arg);
            }

            if (arg is double)
            {
                return GetIEEEBinaryString((double)arg);
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
                return this;
            else
                return null;
        }

        private string GetIEEEBinaryString(double number)
        {
            var convertion = new ConversionDoubleToLong { DoubleBitsForm = number };
            long numberLong = convertion.LongBitsForm;
            int countOfBit = sizeof(double) * 8;
            char[] resultArray = new char[countOfBit];
            resultArray[0] = numberLong < 0 ? '1' : '0';

            for (int i = countOfBit - 2, j = 1; i >= 0; i--, j++)
            {
                resultArray[j] = (numberLong & (1L << i)) != 0 ? '1' : '0';
            }

            return new string(resultArray);
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct ConversionDoubleToLong
        {
            [FieldOffset(0)]
            private readonly long long64bit;

            [FieldOffset(0)]
            private double double64bit;

            public long LongBitsForm => long64bit;
            public double DoubleBitsForm
            {
                set => double64bit = value;
            }
        }
    }
}
