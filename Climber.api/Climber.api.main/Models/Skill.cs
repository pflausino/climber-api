using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace Climber.api.main.Models
{
    public class Skill
    {
        [BsonId]
        public Guid Id { get; set; }
        [BsonElement("skillName")]
        public string SkillName { get; set; }
        [BsonElement("administrativeSkill")]
        public bool AdministrativeSkill { get; set; }

    }
}