using RestfulApi.Business.Interfaces;
using RestfulApi.Models.Data.Converter.Implementations;
using RestfulApi.Models.Data.VO;
using RestfulApi.Repository.Interfaces;
using System.Collections.Generic;

namespace RestfulApi.Business.Implementations
{
    public class PersonBusiness : IPersonBusiness
    {
        private readonly IPersonRepository _personRepository;
        private readonly PersonConverter _converter;

        public PersonBusiness(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var entity = _converter.Parse(person);
            entity = _personRepository.Create(entity);
            return _converter.Parse(entity);
        }

        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_personRepository.FindAll());
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_personRepository.FindById(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var entity = _converter.Parse(person);
            entity = _personRepository.Update(entity);
            return _converter.Parse(entity);
        }
    }
}
