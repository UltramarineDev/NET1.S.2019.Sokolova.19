using NUnit.Framework;
using System;

namespace StringExtension.Tests
{
    public class CustomFormatProviderTests
    {
        [Test]
        public void TitleYearRepresentationTest__BookInstance_String()
        {
            Book book = new Book()
            {
                Title = "C# in Depth",
                Author = "Jon Skeet",
                Year = 2019,
                PublishingHouse = "Manning",
                Edition = 4,
                Pages = 900,
                Price = 40
            };

            string expected = "C# in Depth, 2019";
            IFormatProvider te = new CustomFormatProvider();
            string actual = string.Format(te, "{0:TE}", book);
            Assert.AreEqual(expected, actual);
        }
    }
}
