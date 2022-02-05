using RestfulApi.Models;
using System.Collections.Generic;

namespace RestfulApi.Services.Interfaces
{
    public interface IBookService
    {
        Book Create(Book book);

        Book FindById(long id);

        List<Book> FindAll();

        Book Update(Book book);

        void Delete(long id);
    }
}
