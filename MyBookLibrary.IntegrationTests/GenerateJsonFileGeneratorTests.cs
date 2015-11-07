using MyBookLibrary.Data;
using MyBookLibrary.Service;
using NUnit.Framework;

namespace MyBookLibrary.IntegrationTests
{
    [TestFixture]
    public class GenerateJsonFileGeneratorTests
    {
        [Test]
        public void TestFileGeneration()
        {
            JsonFileGenerator fileGenerator = new JsonFileGenerator();

            fileGenerator.GenerateJsonDataFile();
        }
    }
}
