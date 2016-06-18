using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using MyBookLibrary.Common;

namespace MyBookLibrary.Data
{
    public class BookDatabaseS3Reader : IBookDatabaseReader
    {
        public string ReadImageFreeFile()
        {
            Uri address = new Uri("https://s3.amazonaws.com/mercury-book-repo/BookImageFree.json");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            var streamString = ReadStreamAsString(stream);
            return streamString;
        }

        public string ReadWithDescriptionFile()
        {
            Uri address = new Uri("https://s3.amazonaws.com/mercury-book-repo/BookWithDescription.json");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            var streamString = ReadStreamAsString(stream);
            return streamString;
        }

        public string ReadFullFile()
        {
            Uri address = new Uri("https://s3.amazonaws.com/mercury-book-repo/Book.json");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            var streamString = ReadStreamAsString(stream);
            return streamString;
        }

        public string ReadFile()
        {
            if (CurrentEnvironment.IsLocal())
                return ReadFullFile();

            return ReadWithDescriptionFile();
        }

        public static string ReadStreamAsString(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return Encoding.UTF8.GetString(ms.ToArray(), 0, ms.ToArray().Count());
            }
        }
    }
}
