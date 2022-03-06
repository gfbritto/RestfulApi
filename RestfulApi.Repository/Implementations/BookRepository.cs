using RestfulApi.Models.Core.Entities;
using RestfulApi.Models.Data.VO;
using RestfulApi.Repository.Interfaces;
using RestfulApi.Repository.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace RestfulApi.Repository.Implementations
{
    public class BookRepository : IBookRepository

    {
        private readonly RestfulApiDbContext _context;

        public BookRepository(RestfulApiDbContext context)
        {
            _context = context;
        }

        public Book Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public void Delete(long id)
        {
            var book = FindById(id);

            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _context.Books
                .SingleOrDefault(book => book.Id == id);
        }

        public Book Update(Book book)
        {
            var result = FindById(book.Id);

            if (result == null)
            {
                return new Book();
            }
            else
            {
                _context.Entry(result).CurrentValues.SetValues(book);
                _context.SaveChanges();
            }
            return book;
        }
    }
}
