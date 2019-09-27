using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public class DoubleProvider : IFormatProvider, ICustomFormatter
    {
        IFormatProvider parentProvider;

        public DoubleProvider() : this(CultureInfo.CurrentCulture) { }
        public DoubleProvider(IFormatProvider parent)
        {
            parentProvider = parent;
        }

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
