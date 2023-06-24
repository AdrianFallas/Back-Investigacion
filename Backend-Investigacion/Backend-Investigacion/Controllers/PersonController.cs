using Investigacion.Aplicacion;
using Investigacion.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Investigacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAllPersons()
        {
            var persons = await _personService.GetAllPersons();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersonById(int id)
        {
            var person = await _personService.GetPersonById(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePerson(Person person)
        {
            await _personService.CreatePerson(person);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePerson(int id, Person person)
        {
            if (id != person.id)
            {
                return BadRequest();
            }

            await _personService.UpdatePerson(person);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson(int id)
        {
            var person = await _personService.GetPersonById(id);

            if (person == null)
            {
                return NotFound();
            }

            await _personService.DeletePerson(person);
            return Ok();
        }

    }
}
