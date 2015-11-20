using MyBookLibrary.RestClients.Model;
using RestSharp;

namespace MyBookLibrary.RestClients
{
    public class GoogleBooksClient
    {
        private readonly IRestClient _client = new RestClient();

        public GoogleBooksClient(string url)
        {
            _client = new RestClient(url);
        }

        public GoogleBooksClient(IRestClient client)
        {
            _client = client;
        }

        public GoogleBook GetGoogleBookApiResult(string url, Method method)
        {
            RestRequest request = new RestRequest(url, method);

            var response = _client.Execute<GoogleBook>(request);

            response.Data = MapIsbn(response.Data);

            return response.Data;
        }

        private GoogleBook MapIsbn(GoogleBook googleBook)
        {
            foreach (var identifier in googleBook.VolumeInfo.IndustryIdentifiers)
            {
                switch (identifier.Type)
                {
                    case "ISBN_10":
                        googleBook.VolumeInfo.Isbn10 = identifier.Identifier;
                        break;
                    case "ISBN_13":
                        googleBook.VolumeInfo.Isbn13 = identifier.Identifier;
                        break;

                }
            }

            return googleBook;
        }


    }
}
