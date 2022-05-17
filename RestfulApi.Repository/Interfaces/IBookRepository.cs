using RestfulApi.Models.Core.Entities;
using RestfulApi.Models.Data.VO;
using System.Collections.Generic;

namespace RestfulApi.Repository.Interfaces
{
    public interface IBookRepository
    {
        Book Create(Book book);

        Book FindById(long id);

        List<Book> FindAll();

        Book Update(Book book);

        void Delete(long id);
    }
}
