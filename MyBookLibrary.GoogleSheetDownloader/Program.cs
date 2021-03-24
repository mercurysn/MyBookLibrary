using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MyBookLibrary.Data;
using MyBookLibrary.RestClients;
using MyBookLibrary.Service;
using MyBookLibrary.Service.Mapper;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.GoogleSheetDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new MapToModelProfile()));

            DownloadGoogleBookFile();

            var yearStatsFile = CreateAndUploadYearStatsFile();

            UploadFileToS3(new []{ yearStatsFile });
        }

        private static string CreateAndUploadYearStatsFile()
        {
            var filename = "yearStats.json";

            var readService = new BookReadService(new LocalDatabaseReader());
            var books = readService.GetAll();

            var aggResult = books.YearStats().Select( x => new
            {
                field = x.Field, 
                value = x.Value
            });

            var fileGenerator = new JsonFileGenerator(readService);

            fileGenerator.GenerateGenericJsonDataFile(aggResult, filename);

            return filename;
        }

        private static void UploadFileToS3(string[] filenames)
        {
            AmazonS3Client s3Client = new AmazonS3Client();

            s3Client.SendFileToS3("BookImageFree.json");
            s3Client.SendFileToS3("BookWithDescription.json");

            foreach (var filename in filenames)
            {
                s3Client.SendFileToS3(filename);
            }
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
