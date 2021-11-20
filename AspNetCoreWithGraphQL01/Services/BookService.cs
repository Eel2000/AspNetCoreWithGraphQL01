using AspNetCoreWithGraphQL01.Interfaces;
using AspNetCoreWithGraphQL01.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithGraphQL01.Services
{
    public class BookService : IBookService
    {
        private ObservableCollection<Book> Books;
        public BookService()
        {
            Books = new ObservableCollection<Book>
            {
                new Book
                {
                    ID=1,
                    Title = "one",
                    Pages=400,
                    Author="hes",
                    PublicationDate=DateTime.Now.AddYears(-4)
                },new Book
                {
                    ID=2,
                    Title = "two",
                    Pages=300,
                    Author="shes",
                    PublicationDate=DateTime.Now.AddYears(-5)
                },new Book
                {
                    ID=3,
                    Title = "tree",
                    Pages=250,
                    Author="hs",
                    PublicationDate=DateTime.Now.AddYears(-2)
                },new Book
                {
                    ID=4,
                    Title = "four",
                    Pages=40,
                    Author="th",
                    PublicationDate=DateTime.Now.AddYears(-1)
                },
            };
        }

        public string addBook(Book book)
        {
            book.ID = Books.Count() + 1;
            Books.Add(book);
            return book.ID.ToString();
        }

        public string DeleteBook(int id)
        {
            var bookToDelete = Books.FirstOrDefault(x => x.ID == id);
            if (bookToDelete is null) return "not found";
            Books.Remove(bookToDelete);
            Books.CollectionChanged += Books_CollectionChanged;
            return bookToDelete.ID.ToString();
        }

        private void Books_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("A book have been removed");
        }

        public Book GetBook(int id) => Books.FirstOrDefault(x => x.ID == id);

        public IEnumerable<Book> GetBooks() => Books.ToList();
    }
}
