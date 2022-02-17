using RestfulApi.Business.Interfaces;
using RestfulApi.Models;
using RestfulApi.Repository.Generic;
using System.Collections.Generic;

namespace RestfulApi.Business.Implementations
{
    public class BookBusiness : IBookBusiness
    {
        private readonly IRepository<Book> _Repository;

        public BookBusiness(IRepository<Book> repository)
        {
            _Repository = repository;
        }

        public Book Create(Book book)
        {
            return _Repository.Create(book);
        }

        public void Delete(long id)
        {
            _Repository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _Repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _Repository.FindById(id);
        }

        public Book Update(Book book)
        {
            return _Repository.Update(book);
        }
    }
}
