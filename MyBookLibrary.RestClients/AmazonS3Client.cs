using System;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace MyBookLibrary.RestClients
{
    public class AmazonS3Client
    {
        private const string bucketName = "mercury-book-repo";
        private const string keyName = "abc";
        private const string filePath = @"C:\source\MyBookLibrary\MyBookLibrary.Data\Database\BookImageFree.json";

        static IAmazonS3 _client;

        public bool SendFileToS3(string fileNameInS3 = "BookImageFree.json")
        {
            string localFilePath = string.Concat(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Database\", fileNameInS3);
            using (_client = new Amazon.S3.AmazonS3Client(Amazon.RegionEndpoint.USEast1))
            {
                // create a TransferUtility instance passing it the IAmazonS3 created in the first step
                TransferUtility utility = new TransferUtility(_client);
                // making a TransferUtilityUploadRequest instance
                TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();

                
                request.BucketName = bucketName; //no subdirectory just bucket name
                request.Key = fileNameInS3; //file name up in S3
                request.FilePath = localFilePath; //local file name

                utility.Upload(request); //commensing the transfer

                return true; //indicate that the file was sent
            }
        }
    }
}
