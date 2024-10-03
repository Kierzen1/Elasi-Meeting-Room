using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Services
{
    public class BookService : IBookService
    {
        private readonly iBookRepository _bookRepository;
        public BookService(iBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        public (bool,IEnumerable<Book>) GetBooks()
        {

            var books = _bookRepository.ViewBooks();
            if (books != null) 
            { 
            return (true,books);
            }
            return (false,null);   
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentException();
            }
            var newBook = new Book();
           
            newBook.Title = book.Title;
            newBook.Description = book.Description;
            newBook.Author = book.Author;
            _bookRepository.AddBook(newBook);

        }
        public void DeleteBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentException();
            }


            _bookRepository.DeleteBook(book);
        }

        public void UpdateBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentException();
            }


            _bookRepository.UpdateBook(book);
        }

        
    }
}
