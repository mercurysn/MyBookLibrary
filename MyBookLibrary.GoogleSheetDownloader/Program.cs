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

            DownloadGoogleBookFile();

            UploadFileToS3();
        }

        private static void UploadFileToS3()
        {
            AmazonS3Client s3Client = new AmazonS3Client();

            s3Client.SendFileToS3();
        }

        private static void DownloadGoogleBookFile()
        {
            GoogleDriveClient client = new GoogleDriveClient();

            client.DownloadBookCsv();

            JsonFileGenerator fileGenerator = new JsonFileGenerator(new BookReadService(new LocalDatabaseReader()));

            fileGenerator.GenerateJsonDataFile();
            fileGenerator.PersistGoogleBooksDataIntoFile();
        }
    }
}
