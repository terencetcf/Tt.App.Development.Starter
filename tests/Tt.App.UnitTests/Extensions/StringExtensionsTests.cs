using NUnit.Framework;
using System;
using Tt.App.Extensions;

namespace Tt.App.UnitTests.Extensions
{
    public class StringExtensionsTests
    {
        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase("Test/", "Test")]
        [TestCase("Test@", "Test")]
        public void RemovePostFix_Always_ReturnExpectedResult(string value, string expectedResult)
        {
            var result = value.RemovePostFix("/", "@");

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void RemovePostFix_IfPostFixesIsNull_ReturnExpectedResult()
        {
            var result = "Test@".RemovePostFix();

            Assert.AreEqual("Test@", result);
        }

        [Test]
        public void IsNullOrEmpty_IfNull_ReturnExpectedResult()
        {
            string[] value = null;

            var result = value.IsNullOrEmpty();

            Assert.IsTrue(result);
        }

        [Test]
        public void IsNullOrEmpty_IfEmpty_ReturnExpectedResult()
        {
            var value = new string[] { };

            var result = value.IsNullOrEmpty();

            Assert.IsTrue(result);
        }

        [Test]
        public void IsNullOrEmpty_Always_ReturnExpectedResult()
        {
            var value = new string[] { "1", "2" };

            var result = value.IsNullOrEmpty();

            Assert.IsFalse(result);
        }

        [Test]
        public void Left_IfNull_ReturnExpectedResult()
        {
            string value = null;

            Assert.Throws<ArgumentNullException>(() => value.Left(1));
        }

        [Test]
        public void Left_IfStringLengthSmallerThanRequestLength_ReturnExpectedResult()
        {
            string value = "abc";

            Assert.Throws<ArgumentException>(() => value.Left(4));
        }

        [Test]
        public void Left_Always_ReturnExpectedResult()
        {
            string value = "abcc";

            var result = value.Left(3);

            Assert.AreEqual("abc", result);
        }
    }
}
