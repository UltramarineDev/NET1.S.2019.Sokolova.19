using System;
using System.Text;

namespace StringExtension
{
    public static class StringConverter
    {
        public static string Convert(string source, int count)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException("Source string can not be null, empty or consisit only of white-space characters.", nameof(source));
            }

            if (count <= 0)
            {
                throw new ArgumentException("Number of iterations can not be less or equals zero.", nameof(count));
            }

            var resultString = new StringBuilder();

            while (count != 0)
            {
                for (int i = 0; i < source.Length; i += 2)
                {
                    resultString.Append(source[i]);
                }

                for (int i = 1; i < source.Length; i += 2)
                {
                    resultString.Append(source[i]);
                }

                source = resultString.ToString();
                resultString.Clear();
                count--;
            }

            return source;
        }
    }
}
