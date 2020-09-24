using System;
using System.Collections.Generic;
using System.Linq;
using TestTask_Kyryl.Contexts;
using TestTask_Kyryl.Interfaces;
using TestTask_Kyryl.Models;

namespace TestTask_Kyryl.DAO
{
    public class BookDAO : IBookDAO
    {
        private readonly BookContext db;
        public BookDAO()
        {
            db = new BookContext();
        }
        public IEnumerable<Book> GetAllBooks()
        {
            var debbug = db.Books.ToList();
            return debbug;
        }
        public Book GetBookById(int id)
        {
            return db.Books.First(book => book.Id == id);
        }
        public void DeleteBook(Book bookToDelete)
        {
            db.Books.Remove(bookToDelete);
            db.SaveChanges();
        }
        public Book UpdateBook(Book book)
        {
            var bookInDb = this.GetBookById(book.Id);

            bookInDb.Author = book.Author;
            bookInDb.Name = book.Name;
            bookInDb.Price = book.Price;

            db.SaveChanges();

            return book;
        }
        public Book InsertBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();

            return book;
        }
    }
}
