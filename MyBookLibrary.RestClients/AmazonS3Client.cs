using System;
using System.IO;
using System.Net;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace MyBookLibrary.RestClients
{
    public class AmazonS3Client
    {
        private const string BucketName = "mercury-book-repo";
        static IAmazonS3 _client;

        public bool SendFileToS3(string fileNameInS3)
        {
            string localFilePath = string.Concat(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Database\", fileNameInS3);
            using (_client = new Amazon.S3.AmazonS3Client(Amazon.RegionEndpoint.USEast1))
            {
                
                TransferUtility utility = new TransferUtility(_client);
                TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();

                
                request.BucketName = BucketName; 
                request.Key = fileNameInS3; 
                request.FilePath = localFilePath; 

                utility.Upload(request); 

                Console.Write($"File {fileNameInS3} uploaded.");

                return true; 
            }
        }

        public string SendUrlToS3(string url, string filename)
        {
            using (_client = new Amazon.S3.AmazonS3Client(Amazon.RegionEndpoint.USEast1))
            {

                var webClient = new WebClient();
                var fileStream = webClient.OpenRead(url);

                var fileBytes = ToArrayBytes(fileStream);

                var request = new PutObjectRequest
                {
                    BucketName = $"{BucketName}/img",
                    Key = $"{filename}.jpg", 
                    InputStream = new MemoryStream(fileBytes)
                };
                var response = _client.PutObject(request);

                Console.WriteLine($"File {url} downloaded to s3.");

                return string.Concat("https://", $"mercury-book-repo.s3.amazonaws.com/img/{filename}.jpg");
            }
        }

        public static byte[] ToArrayBytes(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
