using RestfulApi.Models.Core.Entities;
using RestfulApi.Models.Data.VO;
using System.Collections.Generic;

namespace RestfulApi.Business.Interfaces
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);

        PersonVO FindById(long id);

        List<PersonVO> FindAll();

        PersonVO Update(PersonVO person);

        void Delete(long id);
    }
}
