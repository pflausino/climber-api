using Newtonsoft.Json;
using System;

namespace Climber.api.main.Models
{
    public class Skill
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "skillName")]
        public string SkillName { get; set; }
        [JsonProperty(PropertyName = "administrativeSkill")]
        public bool AdministrativeSkill { get; set; }

    }
}