using System.Collections.Generic;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.Service
{
    public interface IBookReadService
    {
        Book GetBookFromId(int id);
        List<Book> GetAll();
        List<Book> ReadAllFromLocalImageFreeFile();
        List<Book> ReadAllFromLocalFullFile();
        List<Book> ReadAllFromLocalWithDescriptionFile();
    }
}