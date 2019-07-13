using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Climber.api.main.Infra;
using Climber.api.main.Models;
using Climber.api.main.Services;
using Microsoft.AspNetCore.Mvc;

namespace Climber.api.main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly SkillService _skillService;

        public SkillsController(SkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public ActionResult<Skill> Get()
        {
            var result = _skillService.Get();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Skill> Post([FromBody] Skill skill)
        {
            if (ModelState.IsValid)
            {
                skill.Id = Guid.NewGuid();
                var result = _skillService.Create(skill);
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpDelete("{id}")]
        public ActionResult<Person> Delete(Guid id)
        {
            _skillService.Remove(id);
            return null;
        }
    }
}