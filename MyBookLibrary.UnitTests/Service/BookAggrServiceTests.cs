using System;
using System.Collections.Generic;
using MyBookLibrary.Service;
using MyBookLibrary.Service.Model;
using NUnit.Framework;

namespace MyBookLibrary.UnitTests.Service
{
    [TestFixture]
    public class BookAggrServiceTests
    {
        [Test]
        public void Test_GroupByYear()
        {
            List<Book> books = new List<Book>
            {
                new Book {DateCompleted = new DateTime(2016, 1, 1)},
                new Book {DateCompleted = new DateTime(2015, 1, 1)}
            };

            BookAggrService service = new BookAggrService();

            var groupByYear = service.GroupByYear(books);

            Assert.AreEqual(2, groupByYear.Count);
            Assert.AreEqual(1, groupByYear[0].Books.Count);
            Assert.AreEqual(1, groupByYear[1].Books.Count);
        }
    }
}
