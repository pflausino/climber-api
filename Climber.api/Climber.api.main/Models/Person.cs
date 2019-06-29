using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Climber.api.main.Models
{
    public class Person
    {
        public Person(string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;

        }
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "skillList")]
        public List<Skill> SkillList { get; set; }
    }
}
