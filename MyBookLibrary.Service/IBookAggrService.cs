using System.Collections.Generic;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.Service
{
    public interface IBookAggrService
    {
        List<Series> GroupBySeries(List<Book> books);
    }
}