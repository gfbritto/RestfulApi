using RestfulApi.Models.Core.Entities;
using RestfulApi.Models.Data.Converter.Contract;
using RestfulApi.Models.Data.VO;
using System.Collections.Generic;
using System.Linq;

namespace RestfulApi.Models.Data.Converter.Implementations
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO origin)
        {
            if (origin == null)
            {
                return null;
            }
            else
            {
                return new Person
                {
                    Id = origin.Id,
                    FirstName = origin.FirstName,
                    LastName = origin.LastName,
                    Adress = origin.Adress,
                    Gender = origin.Adress
                };
            }
        }

        public PersonVO Parse(Person origin)
        {
            if (origin == null)
            {
                return null;
            }
            else
            {
                return new PersonVO
                {
                    Id = origin.Id,
                    FirstName = origin.FirstName,
                    LastName = origin.LastName,
                    Adress = origin.Adress,
                    Gender = origin.Adress
                };
            }
        }

        public List<Person> Parse(List<PersonVO> origin)
        {
            if (origin == null || origin.Count == 0)
            {
                return new List<Person>();
            }
            else
            {
                return origin
                    .Select(item => Parse(item))
                    .ToList();
            }
        }

        public List<PersonVO> Parse(List<Person> origin)
        {
            if (origin == null || origin.Count == 0)
            {
                return new List<PersonVO>();
            }
            else
            {
                return origin
                    .Select(item => Parse(item))
                    .ToList();
            }
        }
    }
}
