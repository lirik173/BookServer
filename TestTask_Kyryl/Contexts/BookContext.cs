using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TestTask_Kyryl.Models;

namespace TestTask_Kyryl.Contexts
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\YURA;Database=BooksDB;Trusted_Connection=True;");
        }
    }
}
