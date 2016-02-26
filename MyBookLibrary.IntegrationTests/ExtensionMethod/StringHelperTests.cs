using System;
using MyBookLibrary.Service.ExtensionMethods;
using NUnit.Framework;

namespace MyBookLibrary.IntegrationTests.ExtensionMethod
{
    [TestFixture]
    public class StringHelperTests
    {
        [Test]
        public void Test_Concat_Authors()
        {
            string[] authors = {"Author 1", "Author 2"};

            Assert.AreEqual("Author 1, Author 2", authors.ConcatAuthor());
        }

        [Test]
        public void Test_Concat_Single_Author()
        {
            string[] authors = { "Author 1"};

            Assert.AreEqual("Author 1", authors.ConcatAuthor());
        }
    }
}
