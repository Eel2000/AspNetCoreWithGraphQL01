using AspNetCoreWithGraphQL01.Interfaces;
using AspNetCoreWithGraphQL01.Models;
using AspNetCoreWithGraphQL01.Services;
using NUnit.Framework;
using System.Linq;

namespace AspNetCoreWithGraphQL01_Tests
{
    [TestFixture]
    public class Tests
    {
        private IBookService _bookService;

        [SetUp]
        public void Setup()
        {
            _bookService = new BookService();
        }

        [Test]
        public void GetBooksIsNotNull()
        {
            var books = _bookService.GetBooks();
            Assert.IsNotNull(books);
        }

        [Test]
        public void GetBooksHaveElements()
        {
            var books = _bookService.GetBooks();
            Assert.IsTrue(books.Any());
        }

        [Test]
        public void GetBooksByIdIsNotNull()
        {
            var book = _bookService.GetBook(2);
            Assert.IsNotNull(book);
        }

        [Test]
        public void GetBookByIdDoesNotThrowException()
        {
            Assert.DoesNotThrow(() => _bookService.GetBook(2), "there is an exception");
        }

        [Test]
        public void AddBookDoesNotThroeException()
        {
            var b = new Book
            {
                Title = "Five",
                Author = "GH",
                Pages = 150,
                PublicationDate = System.DateTime.Now.AddYears(-1)
            };

            Assert.DoesNotThrow(() => _bookService.addBook(b), "Exception thrown when inserting new book");
        }

        [Test]
        public void AddBookIsNotNull()
        {
            var b = new Book
            {
                Title = "Five",
                Author = "GH",
                Pages = 150,
                PublicationDate = System.DateTime.Now.AddYears(-1)
            };

            Assert.IsInstanceOf<string>(_bookService.addBook(b));
        }

        [Test]
        public void DeleteBookDoesNotThrowException()
        {
            Assert.DoesNotThrow(() => _bookService.DeleteBook(2), "Exception Thrown when deleting book");
        }

        [Test]
        public void DeletionWorks()
        {
            var del = _bookService.DeleteBook(2);
            var books = _bookService.GetBooks();
            Assert.AreEqual(3, books.Count(), "Excepted");
        }
    }
}