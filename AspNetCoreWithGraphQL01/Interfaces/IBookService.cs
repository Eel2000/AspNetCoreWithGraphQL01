using AspNetCoreWithGraphQL01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithGraphQL01.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        string addBook(Book book);
        string DeleteBook(int id);
    }
}
