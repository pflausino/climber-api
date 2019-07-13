using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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
        [BsonId]
        public Guid Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("skillList")]
        public List<Skill> SkillList { get; set; }
    }

}
