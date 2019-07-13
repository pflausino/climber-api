using Climber.api.main.Infra;
using Climber.api.main.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Climber.api.main.Services
{
    public class PersonService
    {
        private readonly IMongoCollection<Person> _person;

        public PersonService(IClimberstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _person = database.GetCollection<Person>(settings.PersonCollectionName);
        }
        public List<Person> Get() =>
            _person.Find(Person => true).ToList();

        public Person Get(Guid id) =>
            _person.Find<Person>(person => person.Id == id).FirstOrDefault();

        public Person Create(Person Person)
        {
            _person.InsertOne(Person);
            return Person;
        }

        public void Update(Guid id, Person PersonIn) =>
            _person.ReplaceOne(Person => Person.Id == id, PersonIn);

        public void Remove(Person PersonIn) =>
            _person.DeleteOne(Person => Person.Id == PersonIn.Id);

        public void Remove(Guid id) =>
            _person.DeleteOne(Person => Person.Id == id);
    }


}
