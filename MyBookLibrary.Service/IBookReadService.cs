﻿using System.Collections.Generic;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.Service
{
    public interface IBookReadService
    {
        List<Book> GetAll();
        List<Book> ReadAllFromLocalImageFreeFile();
        List<Book> ReadAllFromLocalFullFile();
        List<Book> ReadAllFromLocalWithImageFile();
        List<Book> ReadAllFromLocalWithDescriptionFile();
    }
}