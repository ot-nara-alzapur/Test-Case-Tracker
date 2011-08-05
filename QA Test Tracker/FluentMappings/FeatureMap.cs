using FluentNHibernate.Mapping;
using QA_Test_Tracker.Models;

namespace QA_Test_Tracker.FluentMappings
{
    public class FeatureMap : ClassMap<Feature>
    {
        public FeatureMap()
        {
            Id(x => x.ID);
            Map(x => x.Name);
            Map(x => x.Description);
        }
    }
}