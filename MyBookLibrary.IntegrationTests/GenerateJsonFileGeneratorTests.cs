using AutoMapper;
using MyBookLibrary.Service;
using MyBookLibrary.Service.Mapper;
using NUnit.Framework;

namespace MyBookLibrary.IntegrationTests
{
    [TestFixture]
    public class GenerateJsonFileGeneratorTests
    {
        [SetUp]
        public void Setup()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new MapToModelProfile()));
        }

        [Test]
        public void FileGeneration()
        {
            JsonFileGenerator fileGenerator = new JsonFileGenerator(new BookReadService());

            fileGenerator.GenerateJsonDataFile();
        }

        [Test]
        public void PersistGoogleBooksData()
        {
            JsonFileGenerator fileGenerator = new JsonFileGenerator(new BookReadService());

            fileGenerator.PersistGoogleBooksDataIntoFile();
        }

        [Test, Explicit]
        public void PersistCoverHashData()
        {
            JsonFileGenerator fileGenerator = new JsonFileGenerator(new BookReadService());

            fileGenerator.PersistCoverHashIntoFile();
        }

        
    }
}
