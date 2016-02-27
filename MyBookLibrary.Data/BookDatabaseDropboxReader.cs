using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace MyBookLibrary.Data
{
    public class BookDatabaseDropboxReader : IBookDatabaseReader
    {
        public static string ReadFile()
        {
            Uri address = new Uri("https://www.sugarsync.com/pf/D6545386_06492321_198651?directDownload=true"); //public link of our file
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            var streamString = ReadStreamAsString(stream);
            return streamString;
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
