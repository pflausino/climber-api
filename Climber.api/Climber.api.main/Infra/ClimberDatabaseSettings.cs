using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Climber.api.main.Infra
{
    public class ClimberDatabaseSettings : IClimberstoreDatabaseSettings
    {
        public string PersonCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string SkillCollectionName { get; set; }
    }
    public interface IClimberstoreDatabaseSettings
    {
        string PersonCollectionName { get; set; }
        string SkillCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
