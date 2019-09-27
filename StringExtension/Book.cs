using System;
using System.Globalization;

namespace StringExtension
{
    /// <summary>
    /// Class Book
    /// </summary>
    /// <seealso cref="System.IFormattable" />
    public class Book : IFormattable
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string PublishingHouse { get; set; }
        public int Edition { get; set; }
        public int Pages { get; set; }
        public uint Price { get; set; }

        /// <summary>
        /// Gets the full name
        /// </summary>
        /// <value>
        /// The full.
        /// </value>
        public string Full
        {
            get
            {
                return Author + ", " + Title + ", " + Year + ", " + PublishingHouse;
            }
        }

        /// <summary>
        /// Gets the general name 
        /// </summary>
        /// <value>
        /// The general.
        /// </value>
        public string General
        {
            get
            {
                return Author + ", " + Title + ", " + Year;
            }
        }

        /// <summary>
        /// Gets the author and title.
        /// </summary>
        /// <value>
        /// The author and title.
        /// </value>
        public string AuthorAndTitle
        {
            get
            {
                return Author + ", " + Title;
            }
        }

        /// <summary>
        /// Gets the name without title
        /// </summary>
        /// <value>
        /// The without author.
        /// </value>
        public string WithoutAuthor
        {
            get
            {
                return Title + ", " + Year + ", " + PublishingHouse;
            }
        }

        /// <summary>
        /// Gets the short name
        /// </summary>
        /// <value>
        /// The short.
        /// </value>
        public string Short
        {
            get
            {
                return Title;
            }
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="FormatException"></exception>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format))
            {
                format = "G";
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpperInvariant())
            {
                case "F":
                    return Full.ToString();
                case "G":
                    return General.ToString();
                case "AT":
                    return AuthorAndTitle.ToString();
                case "W":
                    return WithoutAuthor.ToString();
                case "SH":
                    return Short.ToString();
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
    }
}
