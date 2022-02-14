using RestfulApi.Models;
using System.Collections.Generic;

namespace RestfulApi.Repository.Interfaces
{
    public interface IPersonRepository
    {
        Person Create(Person person);

        Person FindById(long id);

        List<Person> FindAll();

        Person Update(Person person);

        void Delete(long id);
    }
}
