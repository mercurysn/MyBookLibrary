using MyBookLibrary.Service.Model;
using NUnit.Framework;

namespace MyBookLibrary.UnitTests.Model
{
    [TestFixture]
    public class BookModelTests
    {
        [Test]
        public void Test_Book_Equal()
        {
            Book book1 = new Book { Name = "Book 1" };
            Book book2 = new Book { Name = "Book 1" };
            Book book3 = new Book { Name = "Book 2" };

            Assert.IsTrue(book1.Equals(book2));
            Assert.IsFalse(book1.Equals(book3));
        }
    }
}
