using System.Collections.Generic;
using System.Linq;
using MyBookLibrary.Data;
using MyBookLibrary.Service;
using MyBookLibrary.Service.Model;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MyBookLibrary.IntegrationTests.Service
{
    [TestFixture]
    public class StatServiceTests
    {
        private List<Book> _books = new List<Book>();

        [SetUp]
        public void Setup()
        {
            _books = JsonConvert.DeserializeObject<List<Book>>(BookDatabaseReader.ReadFile());

        }

        [Test]
        public void SortByLongestMinute_Tests()
        {
            var sortedList = _books.SortBooksByMinutes();

            Assert.AreEqual("The Rise and Fall of the Third Reich", sortedList[0].Name);
        }

        [Test]
        public void GroupByAuthor_Test()
        {
            var authorReport = _books.GroupByAuthorBookCount();

        }
    }
}
