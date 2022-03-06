using RestfulApi.Models.Core.Entities;
using RestfulApi.Models.Data.VO;
using System.Collections.Generic;

namespace RestfulApi.Business.Interfaces
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);

        BookVO FindById(long id);

        List<BookVO> FindAll();

        BookVO Update(BookVO book);

        void Delete(long id);
    }
}
