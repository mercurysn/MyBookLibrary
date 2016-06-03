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

        [Test]
        public void Test_PersistNewBookToList()
        {
            List<Book> oldList = new List<Book>
            {
                new Book { Name = "Book 1"}
            };

            List<Book> newList = new List<Book>
            {
                new Book { Name = "Book 1"},
                new Book { Name = "Book 2"},
                new Book { Name = "Book 3"}
            };

            oldList = oldList.PersistNewBookToList(newList);

            Assert.AreEqual(3, oldList.Count);

            Assert.AreEqual("Book 1", oldList[0].Name);
            Assert.AreEqual("Book 2", oldList[1].Name);
            Assert.AreEqual("Book 3", oldList[2].Name);
        }

        [Test]
        public void Test_PersistNewBookToList_DestinationNull()
        {
            List<Book> oldList = new List<Book>();

            List<Book> newList = new List<Book>
            {
                new Book { Name = "Book 1"},
                new Book { Name = "Book 2"},
                new Book { Name = "Book 3"}
            };

            oldList = oldList.PersistNewBookToList(newList);

            Assert.AreEqual(3, oldList.Count);

            Assert.AreEqual("Book 1", oldList[0].Name);
            Assert.AreEqual("Book 2", oldList[1].Name);
            Assert.AreEqual("Book 3", oldList[2].Name);
        }

        [Test]
        public void Test_PersistNewBookToList_SourceNull()
        {
            List<Book> oldList = new List<Book>
            {
                new Book { Name = "Book 1"}
            };

            List<Book> newList = new List<Book>();

            oldList = oldList.PersistNewBookToList(newList);

            Assert.AreEqual(1, oldList.Count);

            Assert.AreEqual("Book 1", oldList[0].Name);
        }
    }
}
