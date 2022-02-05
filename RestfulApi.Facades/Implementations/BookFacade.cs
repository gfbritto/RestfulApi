using RestfulApi.Facades.Interfaces;
using RestfulApi.Models;
using RestfulApi.Services.Interfaces;
using System.Collections.Generic;

namespace RestfulApi.Facades.Implementations
{
    public class BookFacade: IBookFacade
    {
        private readonly IBookService _bookService;

        public BookFacade(IBookService bookService)
        {
            _bookService = bookService;
        }

        public Book Create(Book book)
        {
            return _bookService.Create(book);
        }

        public void Delete(long id)
        {
            _bookService.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _bookService.FindAll();
        }

        public Book FindById(long id)
        {
            return _bookService.FindById(id);
        }

        public Book Update(Book book)
        {
            return _bookService.Update(book);
        }
    }
}
