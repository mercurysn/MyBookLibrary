using System;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace MyBookLibrary.RestClients
{
    public class GoogleDriveClient
    {
        static readonly string[] Scopes = { DriveService.Scope.DriveReadonly };
        private const string ApplicationName = "Drive API .NET Quickstart";
        private static DriveService _service;

        public GoogleDriveClient()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            _service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            //// Define parameters of request.
            //FilesResource.ListRequest listRequest = _service.Files.List();
            //listRequest.PageSize = 100;
            //listRequest.Fields = "nextPageToken, files(id, name)";

            //// List files.
            //IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
            //    .Files;
            //Console.WriteLine("Files:");
            //if (files != null && files.Count > 0)
            //{
            //    foreach (var file in files)
            //    {
            //        Console.WriteLine("{0} ({1})", file.Name, file.Id);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No files found.");
            //}
            //Console.Read();
        }

        public void DownloadBookCsv()
        {
            var fileId = "1PCIzU29Cc5bmjlYqwn2XEpiAGt8UZPGU-4IomgUQgIY";
            var request = _service.Files.Export(fileId, "text/csv");
            var stream = new System.IO.MemoryStream();
            // Add a handler which will be notified on progress changes.
            // It will notify on each chunk download and when the
            // download is completed or failed.
            request.MediaDownloader.ProgressChanged +=
                    (IDownloadProgress progress) =>
                    {
                        switch (progress.Status)
                        {
                            case DownloadStatus.Downloading:
                                {
                                    Console.WriteLine(progress.BytesDownloaded);
                                    break;
                                }
                            case DownloadStatus.Completed:
                                {
                                    Console.WriteLine("Download complete.");
                                    break;
                                }
                            case DownloadStatus.Failed:
                                {
                                    Console.WriteLine("Download failed.");
                                    break;
                                }
                        }
                    };
            request.Download(stream);

            
            FileStream file = new FileStream(@"C:\Source\MyBookLibrary\MyBookLibrary.Data\Source\Shelfari.csv", FileMode.Create, FileAccess.Write);
            stream.WriteTo(file);
            file.Close();
            stream.Close();

            Console.WriteLine($"File saved to {@"C:\Source\MyBookLibrary\MyBookLibrary.Data\Source\Shelfari.csv"}");
        }
    }
}
