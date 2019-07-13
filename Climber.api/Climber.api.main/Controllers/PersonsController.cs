using Climber.api.main.Infra;
using Climber.api.main.Models;
using Climber.api.main.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Climber.api.main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersonService _personService;

        public PersonsController( PersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public ActionResult<List<Person>> Get()
        {
            var result = _personService.Get();

            return Ok(result);

        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(Guid id)
        {
            return _personService.Get(id);
        }

        [HttpDelete("{id}")]
        public ActionResult<Person> Delete(Guid id)
        {
            _personService.Remove(id);
            return null;
        }
        [HttpPost]
        public ActionResult<Person> Post([FromBody] Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = Guid.NewGuid();
                var result = _personService.Create(person);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("{personId}")]
        public ActionResult<Person> Put([FromBody] Person person, Guid personId)
        {
            if (ModelState.IsValid)
            {
                _personService.Update(personId, person);
                return Ok();
            }

            return BadRequest();
        }
    }
}