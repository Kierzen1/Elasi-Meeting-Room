using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Repositories
{
    public class BookRepository : BaseRepository, iBookRepository
    {
        List<Book> _allBook = new();
        private readonly AsiBasecodeDBContext _dbContext;

        public BookRepository(AsiBasecodeDBContext dbContext, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Book> ViewBooks()
        {
            return _dbContext.Books.ToList();
        }

        public void AddBook(Book book)
        {
            try
            {
                var newBook = new Book();
                newBook.Title = book.Title;
                newBook.Description = book.Description;
                newBook.Author = book.Author;
                _dbContext.Books.Add(newBook);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new InvalidDataException("error adding books");
            }
        }
        public void DeleteBook(Book book)
        {
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            var existingBook = _dbContext.Books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Description = book.Description;
                existingBook.Author = book.Author;

                _dbContext.Books.Update(existingBook);
                _dbContext.SaveChanges();
  
            }
        }

        public (bool, IEnumerable<Book>) GetBooks()
        {
            throw new NotImplementedException();
        }
    }
}
