using RestfulApi.Business.Interfaces;
using RestfulApi.Models.Core.Entities;
using RestfulApi.Models.Data.Converter.Implementations;
using RestfulApi.Models.Data.VO;
using RestfulApi.Repository.Interfaces;
using System.Collections.Generic;

namespace RestfulApi.Business.Implementations
{
    public class BookBusiness : IBookBusiness
    {
        private readonly IBookRepository _bookRepository;
        private readonly BookConverter _converter;

        public BookBusiness(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            var entity = _converter.Parse(book);
            entity = _bookRepository.Create(entity);
            return _converter.Parse(entity);
        }

        public void Delete(long id)
        {
            _bookRepository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_bookRepository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_bookRepository.FindById(id));
        }

        public BookVO Update(BookVO book)
        {
            var entity = _converter.Parse(book);
            entity = _bookRepository.Update(entity);
            return _converter.Parse(entity);
        }
    }
}
