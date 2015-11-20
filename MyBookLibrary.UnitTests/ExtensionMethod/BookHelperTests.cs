using System.Collections.Generic;
using MyBookLibrary.Service.ExtensionMethods;
using MyBookLibrary.Service.Model;
using NUnit.Framework;

namespace MyBookLibrary.UnitTests.ExtensionMethod
{
    [TestFixture]
    public class BookHelperTests
    {
        [Test]
        public void Test_Author_DenormaliseAuthors_Method()
        {
            List<Book> books = new List<Book>
            {
                new Book
                {
                    Author = new string[] {"Author 1", "Author 2", "Author 3"},
                    Name = "Book 1"
                },
                new Book
                {
                    Author = new string[] {"Author 4"},
                    Name = "Book 2"
                }
            };

            books = books.DenormaliseAuthors();

            Assert.AreEqual("Author 1", books[0].Author[0]);
            Assert.AreEqual("Author 4", books[1].Author[0]);
            Assert.AreEqual("Author 2", books[2].Author[0]);
            Assert.AreEqual("Author 3", books[3].Author[0]);
            Assert.AreEqual(4, books.Count);
        }
    }
}
