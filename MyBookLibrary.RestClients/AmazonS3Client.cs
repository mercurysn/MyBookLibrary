using System;
using Amazon.S3;
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
    }
}
