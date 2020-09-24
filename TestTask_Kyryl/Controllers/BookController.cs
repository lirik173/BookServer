using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask_Kyryl.Models;
using TestTask_Kyryl.Services;

namespace TestTask_Kyryl.Controllers
{
    [ApiController]
    [Route("book")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookService.GetAllBooks();
        }
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            try
            {
                return _bookService.GetBook(id);
            }
            catch
            {
                throw new NullReferenceException("Book not found");
            }
        }

        [HttpPut("{id}")]
        public Book Put(int id, [FromBody]BookDTO book)
        {
            try
            {
                return _bookService.UpdateBook(id, book);
            }
            catch(Exception ex)
            {
                throw new NullReferenceException("Book was not found");
            }
        }

        [HttpPost]
        public Book Post([FromBody]BookDTO book)
        {
            try
            {
                return _bookService.InsertBook(book);
            }
            catch
            {
                throw new Exception("Error occured while trying to add new book");
            }

        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _bookService.DeleteBook(id);
            }
            catch
            {
                throw new NullReferenceException("Book was not found");
            }
        }
    }
}
