using RestfulApi.Models;
using System.Collections.Generic;

namespace RestfulApi.Facades.Interfaces
{
    public interface IBookFacade
    {
        Book Create(Book book);

        Book FindById(long id);

        List<Book> FindAll();

        Book Update(Book book);

        void Delete(long id);
    }
}
