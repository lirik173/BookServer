using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask_Kyryl.Models;

namespace TestTask_Kyryl.Interfaces
{
    public interface IBookDAO
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void DeleteBook(Book bookToDelete);
        Book UpdateBook(Book book);
        Book InsertBook(Book book);
    }
}
