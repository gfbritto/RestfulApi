using Microsoft.AspNetCore.Mvc;
using RestfulApi.Business.Interfaces;
using RestfulApi.Models.Data.VO;
using System.Collections.Generic;

namespace RestfulApi.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonBusiness _personFacade;

        public PersonController(IPersonBusiness personBusiness)
        {
            _personFacade = personBusiness;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetAllPersons()
        {
            var result = _personFacade.FindAll();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var result = _personFacade.FindById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult Create([FromBody] PersonVO person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            var result = _personFacade.Create(person);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePerson([FromBody] PersonVO person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_personFacade.Update(person));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult Delete(long id)
        {
            _personFacade.Delete(id);
            return NoContent();
        }
    }
}