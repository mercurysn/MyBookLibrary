using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MyBookLibrary.Data;
using MyBookLibrary.Data.Dtos;
using MyBookLibrary.RestClients;
using MyBookLibrary.Service.ExtensionMethods;
using MyBookLibrary.Service.Model;
using Newtonsoft.Json;
using RestSharp;

namespace MyBookLibrary.Service
{
    public class JsonFileGenerator
    {
        private readonly IBookReadService _bookReadService;

        public JsonFileGenerator(IBookReadService bookReadService)
        {
            _bookReadService = bookReadService;
        }

        public void GenerateJsonDataFile()
        {
            var bookDtos = GetBookDtos();

            var books = GetBookModel(bookDtos);

            BookDatabaseWriter.SaveToImageFreeFile(JsonConvert.SerializeObject(books, Formatting.Indented));
        }

        public void PersistGoogleBooksDataIntoFile()
        {
            var imageFreeBooks = _bookReadService.ReadAllFromLocalImageFreeFile();

            var withImageBooks = _bookReadService.ReadAllFromLocalWithDescriptionFile().PersistNewBookToList(imageFreeBooks);

            withImageBooks = PersistGoogleBookFields(withImageBooks);

            BookDatabaseWriter.SaveToWithDescriptionFile(JsonConvert.SerializeObject(withImageBooks, Formatting.Indented));
        }

        

        public void PersistCoverHashIntoFile()
        {
            var withDescriptionBooks = _bookReadService.ReadAllFromLocalWithDescriptionFile();

            var fullFileBooks = _bookReadService.ReadAllFromLocalFullFile().PersistNewBookToList(withDescriptionBooks); ;

            foreach (var book in fullFileBooks)
            {
                    book.CoverHash = book.CoverUrl.ToBase64();
            }

            BookDatabaseWriter.SaveToFullFile(JsonConvert.SerializeObject(fullFileBooks, Formatting.Indented));
        }

        private static List<Book> GetBookModel(List<BookDto> bookDtos)
        {
            List<Book> books = AutoMapper.Mapper.Map<List<Book>>(bookDtos);

            int index = 1;
            foreach (var book in books)
            {
                book.Id = index++;
            }

            return books;
        }



        private static List<Book> PersistGoogleBookFields(List<Book> books)
        {
            foreach (var book in books)
            {
                if (string.IsNullOrWhiteSpace(book.GoogleBookId) || !string.IsNullOrWhiteSpace(book.Description))
                    continue;

                GoogleBooksClient client = new GoogleBooksClient("https://www.googleapis.com");

                var googleBook = client.GetGoogleBookApiResult(string.Format("books/v1/volumes/{0}?key=AIzaSyDhHJkRg7Yv6Z4hpw0OGsuMUl_WIlWpj20", book.GoogleBookId), Method.GET);

                if (googleBook?.VolumeInfo == null)
                {
                    book.GoogleError = true;
                    continue;
                }

                book.Description = googleBook.VolumeInfo.Description;
                book.Publisher = googleBook.VolumeInfo.Publisher;
                book.Isbn10 = googleBook.VolumeInfo.Isbn10;
                book.Isbn13 = googleBook.VolumeInfo.Isbn13;
                book.GoogleBookLink = googleBook.selfLink;
                book.Categories = googleBook.VolumeInfo.Categories;
                book.CrowdRating = googleBook.VolumeInfo.averageRating;
                book.GoogleError = false;
            }

            return books;
        }

        private static List<BookDto> GetBookDtos()
        {
            BookRepository repository = new BookRepository();

            var bookDtos = repository.GetAllBookDtos();
            return bookDtos;
        }
    }

}
