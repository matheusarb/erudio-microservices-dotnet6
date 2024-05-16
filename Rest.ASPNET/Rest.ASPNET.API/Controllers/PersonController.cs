using Microsoft.AspNetCore.Mvc;
using Rest.ASPNET.API.Models;
using Rest.ASPNET.API.Services;

namespace Rest.ASPNET.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetAllPeople()
            => Ok(_personService.FindAll());

        [HttpGet("getById/{id}")]
        public IActionResult GetPersonById(long id)
        {
            var person = _personService.FindById(id);
            if (person is null)
                return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            if (person is null)
                return BadRequest();
            return Created($"/{person.Id}", _personService.Create(person));
        }
        
        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            if (person is null)
                return BadRequest();
            return Created($"/{person.Id}", _personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var person = _personService.FindById(id);
            if (person is null)
                return BadRequest();

            _personService.Delete(person.Id);
            return NoContent();
        }
    }
}
