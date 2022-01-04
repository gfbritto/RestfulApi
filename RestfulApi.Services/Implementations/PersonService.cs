using RestfulApi.Models;
using RestfulApi.Services.Interfaces;
using RestfulApi.Services.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace RestfulApi.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly RestfulApiDbContext _dbContext;

        public PersonService(RestfulApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Person> FindAll()
        {
            return _dbContext.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _dbContext.Persons
                .SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            _dbContext.Persons.Add(person);
            _dbContext.SaveChanges();
            return person;
        }

        public Person Update(Person person)
        {
            var result = FindById(person.Id);

            if (result == null)
            {
                return new Person();
            }
            else
            {
                _dbContext.Entry(result).CurrentValues.SetValues(person);
                _dbContext.SaveChanges();
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = FindById(id);

            if (result != null)
            {
                _dbContext.Persons.Remove(result);
                _dbContext.SaveChanges();
            }
        }
    }
}
