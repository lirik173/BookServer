using AutoMapper;
using System;
using System.Collections.Generic;
using TestTask_Kyryl.DAO;
using TestTask_Kyryl.Models;

namespace TestTask_Kyryl.Services
{
    public class BookService : IBookService
    {
        private readonly BookDAO dao;
        private readonly Mapper mapper;
        public BookService()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, Book>());
            mapper = new Mapper(config);
            dao = new BookDAO();
        }
        public void DeleteBook(int id)
        {
            dao.DeleteBook(this.GetBook(id));
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return dao.GetAllBooks();
        }
        public Book GetBook(int id)
        {
            return dao.GetBookById(id);
        }
        public Book InsertBook(BookDTO bookDTO)
        {
            Book book = mapper.Map<Book>(bookDTO);

            return dao.InsertBook(book);
        }

        public Book UpdateBook(int id, BookDTO bookDTO)
        {
            var bookFromDB = this.GetBook(id);
            Book book = mapper.Map<Book>(bookDTO);
            book.Id = bookFromDB.Id;

            return dao.UpdateBook(book);
        }
    }
}
