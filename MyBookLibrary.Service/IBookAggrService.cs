using System.Collections.Generic;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.Service
{
    public interface IBookAggrService
    {
        List<Author> GroupByAuthor(List<Book> books);

        List<Author> GroupByMultiAuthor(List<Book> books);

        List<Series> GroupBySeries(List<Book> books);

        List<BookGroupDto> GroupByYear(List<Book> books);

        List<BookGroupDto> GroupByMonth(List<Book> books);
    }
}