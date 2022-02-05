using RestfulApi.Facades.Interfaces;
using RestfulApi.Models;
using RestfulApi.Services.Interfaces;
using System.Collections.Generic;

namespace RestfulApi.Facades.Implementations
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;

        public PersonFacade(IPersonService personService)
        {
            _personService = personService;
        }
        public Person Create(Person person)
        {
            return _personService.Create(person);
        }

        public void Delete(long id)
        {
            _personService.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _personService.FindAll();
        }

        public Person FindById(long id)
        {
            return _personService.FindById(id);
        }

        public Person Update(Person person)
        {
            return _personService.Update(person);
        }
    }
}
