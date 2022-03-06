using Microsoft.AspNetCore.Mvc;
using RestfulApi.Business.Interfaces;
using RestfulApi.Models.Data.VO;

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
        public IActionResult UpdatePerson([FromBody] PersonVO person)
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