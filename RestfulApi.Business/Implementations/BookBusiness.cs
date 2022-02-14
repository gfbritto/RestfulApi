using RestfulApi.Business.Interfaces;
using RestfulApi.Models;
using RestfulApi.Repository.Interfaces;
using System.Collections.Generic;

namespace RestfulApi.Business.Implementations
{
    public class BookBusiness : IBookBusiness
    {
        private readonly IBookRepository _bookRepository;

        public BookBusiness(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book Create(Book book)
        {
            return _bookRepository.Create(book);
        }

        public void Delete(long id)
        {
            _bookRepository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _bookRepository.FindAll();
        }

        public Book FindById(long id)
        {
            return _bookRepository.FindById(id);
        }

        public Book Update(Book book)
        {
            return _bookRepository.Update(book);
        }
    }
}
