using System.Collections.Generic;
using System.Data;
using TestTask_Kyryl.Models;

namespace TestTask_Kyryl.Services
{
    public interface IBookService
    {
        public IEnumerable<Book> GetAllBooks();
        public Book GetBook(int id);
        public void DeleteBook(int id);
        Book UpdateBook(int id, BookDTO bookDTO);
        Book InsertBook(BookDTO bookDTO);
    }
}