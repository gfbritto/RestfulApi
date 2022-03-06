using Microsoft.AspNetCore.Mvc;
using RestfulApi.Business.Interfaces;
using RestfulApi.Models.Core.Entities;

namespace RestfulApi.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {
        private readonly IBookBusiness _bookFacade;

        public BookController(IBookBusiness bookFacade)
        {
            _bookFacade = bookFacade;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var result = _bookFacade.FindAll();

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var result = _bookFacade.FindById(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            var result = _bookFacade.Create(book);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Book book)
        {
            return Ok(_bookFacade.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookFacade.Delete(id);
            return NoContent();
        }
    }
}
