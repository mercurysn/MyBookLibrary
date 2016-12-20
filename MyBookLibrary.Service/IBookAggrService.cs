using System.Collections.Generic;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.Service
{
    public interface IBookAggrService
    {
        List<Series> GroupBySeries(List<Book> books);

        List<BookGroupDto> GroupByYear(List<Book> books);

        List<BookGroupDto> GroupByMonth(List<Book> books);
    }
}