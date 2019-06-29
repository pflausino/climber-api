using Climber.api.main.Infra;
using Climber.api.main.Models;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {
            var result = await DocumentDBRepository<Person>.GetItemsAsync();

            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(Guid id)
        {
            return await DocumentDBRepository<Person>.GetItemAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> Post([FromBody] Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = Guid.NewGuid();
                var result = await DocumentDBRepository<Person>.CreateItemAsync(person);
                return Ok(result);
            }

            return BadRequest();
        }
    }
}