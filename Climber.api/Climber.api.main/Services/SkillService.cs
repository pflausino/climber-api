using Climber.api.main.Infra;
using Climber.api.main.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Climber.api.main.Services
{
    public class SkillService
    {
        private readonly IMongoCollection<Skill> _skill;

        public SkillService(IClimberstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _skill = database.GetCollection<Skill>(settings.SkillCollectionName);
        }
        public List<Skill> Get() =>
            _skill.Find(skill => true).ToList();

        public Skill Get(Guid id) =>
            _skill.Find<Skill>(skill => skill.Id == id).FirstOrDefault();

        public Skill Create(Skill skill)
        {
            _skill.InsertOne(skill);
            return skill;
        }

        public void Update(Guid id, Skill SkillIn) =>
            _skill.ReplaceOne(Skill => Skill.Id == id, SkillIn);

        public void Remove(Skill SkillIn) =>
            _skill.DeleteOne(Skill => Skill.Id == SkillIn.Id);

        public void Remove(Guid id) =>
            _skill.DeleteOne(skill => skill.Id == id);
    }
}
