using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Climber.api.main.Infra;
using Climber.api.main.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Climber.api.main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<Skill>> Get()
        {
            var result = await DocumentDBRepositorySkill<Skill>.GetItemsAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Skill>> Post([FromBody] Skill skill)
        {
            if (ModelState.IsValid)
            {
                skill.Id = Guid.NewGuid();
                var result = await DocumentDBRepositorySkill<Skill>.CreateItemAsync(skill);
                return Ok(result);
            }

            return BadRequest();
        }
    }
}