﻿using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Interfaces
{
    public interface IBookService
    {
        (bool,IEnumerable<Book>) GetBooks();

        void AddBook(Book book);

        void DeleteBook(Book book);

        void UpdateBook(Book book);
    }
}
