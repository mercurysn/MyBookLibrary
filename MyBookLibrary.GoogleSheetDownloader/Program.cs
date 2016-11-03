using AutoMapper;
using MyBookLibrary.Data;
using MyBookLibrary.RestClients;
using MyBookLibrary.Service;
using MyBookLibrary.Service.Mapper;

namespace MyBookLibrary.GoogleSheetDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new MapToModelProfile()));

            GoogleDriveClient client = new GoogleDriveClient();

            client.DownloadBookCsv();

            JsonFileGenerator fileGenerator = new JsonFileGenerator(new BookReadService(new LocalDatabaseReader()));

            fileGenerator.GenerateJsonDataFile();
            fileGenerator.PersistGoogleBooksDataIntoFile();
        }
    }
}
