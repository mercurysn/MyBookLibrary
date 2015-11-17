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

        [Test, Explicit]
        public void FileGeneration()
        {
            JsonFileGenerator fileGenerator = new JsonFileGenerator();

            fileGenerator.GenerateJsonDataFile();


        }
    }
}
