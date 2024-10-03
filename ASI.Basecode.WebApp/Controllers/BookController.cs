using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ASI.Basecode.WebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService _bookService)
        {
            this._bookService = _bookService;
        }

        public ActionResult Index()
        {
            (bool result, IEnumerable<Book> books) = _bookService.GetBooks();
            if (result)
            {
                return View(books);
            }
            return View(null);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            try
            {
                _bookService.AddBook(book);
                return RedirectToAction("Index", "Book");
            }
            catch (InvalidDataException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View();
        }

        public IActionResult Delete(int Id)
        {
            (bool result, IEnumerable<Book> books) = _bookService.GetBooks();
            var book = books.FirstOrDefault(book => Id == book.Id);
            if (book != null)
            {
                _bookService.DeleteBook(book);
            }
            return RedirectToAction("Index", "Book");
        }

        public IActionResult Update(int id) 
        {
            (bool result, IEnumerable<Book> books) = _bookService.GetBooks();
            var book = books.FirstOrDefault(b => id == b.Id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Update(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}
