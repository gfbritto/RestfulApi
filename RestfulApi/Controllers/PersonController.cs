using Microsoft.AspNetCore.Mvc;
using RestfulApi.Facades.Interfaces;
using RestfulApi.Models;

namespace RestfulApi.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonFacade _personFacade;

        public PersonController(IPersonFacade personFacade)
        {
            _personFacade = personFacade;
        }

        [HttpGet]
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
        public IActionResult GetPersonById(int id)
        {
            var result = _personFacade.FindById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            _personFacade.Create(person);
            return CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person);
        }

        [HttpPut]
        public IActionResult UpdatePerson([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_personFacade.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personFacade.Delete(id);
            return NoContent();
        }
    }
}