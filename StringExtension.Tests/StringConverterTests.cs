using System;
using NUnit.Framework;

namespace StringExtension.Tests
{
    public class StringConverterTests
    {
        [TestCase("Привет Епам!", 2, ExpectedResult = "Пепртаи мвЕ!")]
        [TestCase("Привет Епам!", 3, ExpectedResult = "ПптимЕера в!")]
        [TestCase("Hello world", 2, ExpectedResult = "Hore llwdlo")]
        [TestCase("apple", 4, ExpectedResult = "apple")]
        [TestCase("monitor new", 1, ExpectedResult = "mntrnwoio e")]
        [TestCase("new", 5, ExpectedResult = "nwe")]
        public string ConvertTests(string source, int cout)
            => StringConverter.Convert(source, cout);

        [Test]
        public void Convert_SourceIsInvalid_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => StringConverter.Convert(null, 9));
            Assert.Throws<ArgumentException>(() => StringConverter.Convert(string.Empty, 9));
            Assert.Throws<ArgumentException>(() => StringConverter.Convert("   ", 9));
        }

        [Test]
        public void Convert_CountIsInvalid_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => StringConverter.Convert("hello", -9));
        }
    }
}
