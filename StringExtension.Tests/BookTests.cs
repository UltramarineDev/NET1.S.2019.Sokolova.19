using NUnit.Framework;

namespace StringExtension.Tests
{
    public class BookTests
    {
        [Test]
        public void FullRepresentationTest_BookInstance_String()
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

            string expected = "Jon Skeet, C# in Depth, 2019, Manning";
            string actual = book.ToString("F");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GeneralRepresentationTest_BookInstance_String()
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

            string expected = "Jon Skeet, C# in Depth, 2019";
            string actual = book.ToString();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AuthorAndTitleRepresentationTest_BookInstance_String()
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

            string expected = "Jon Skeet, C# in Depth";
            string actual = book.ToString("AT");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WithoutAuthorRepresentationTest_BookInstance_String()
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

            string expected = "C# in Depth, 2019, Manning";
            string actual = book.ToString("W");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShortRepresentationTest_BookInstance_String()
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

            string expected = "C# in Depth";
            string actual = book.ToString("SH");
            Assert.AreEqual(expected, actual);
        }
    }
}
