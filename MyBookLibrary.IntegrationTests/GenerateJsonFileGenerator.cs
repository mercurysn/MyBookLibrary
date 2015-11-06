using MyBookLibrary.Data;
using NUnit.Framework;

namespace MyBookLibrary.IntegrationTests
{
    [TestFixture]
    public class GenerateJsonFileGenerator
    {
        [Test]
        public void TestFileGeneration()
        {
            BookRepository repository = new BookRepository();

            var books = repository.GetAllBookDtos();


        }
    }
}
