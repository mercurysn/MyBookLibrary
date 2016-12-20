using AutoMapper;
using MyBookLibrary.Data;
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

        [Test, Explicit]
        public void FileGeneration()
        {
            JsonFileGenerator fileGenerator = new JsonFileGenerator(new BookReadService(new LocalDatabaseReader()));

            fileGenerator.GenerateJsonDataFile();
        }

        [Test, Explicit]
        public void PersistGoogleBooksData()
        {
            JsonFileGenerator fileGenerator = new JsonFileGenerator(new BookReadService(new LocalDatabaseReader()));

            fileGenerator.PersistGoogleBooksDataIntoFile();
        }

        [Test, Explicit]
        public void PersistCoverHashData()
        {
            JsonFileGenerator fileGenerator = new JsonFileGenerator(new BookReadService(new LocalDatabaseReader()));

            fileGenerator.PersistCoverHashIntoFile();
        }

        
    }
}
