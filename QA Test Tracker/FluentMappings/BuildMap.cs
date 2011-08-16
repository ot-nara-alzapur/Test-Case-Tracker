using FluentNHibernate.Mapping;
using QA_Test_Tracker.Models;

namespace QA_Test_Tracker.FluentMappings
{
    public class BuildMap : ClassMap<Build>
    {
        public BuildMap()
        {
            Id(x => x.ID);
            Map(x => x.BuildNumber);
            References(x => x.Release);
            HasMany(x => x.TestPlans)
                .ForeignKeyConstraintName("FK_Builds_ActiveTestPlans")
                .Inverse();
            References(x => x.Product)
                .ForeignKey("FK_Builds_Products");
        }
    }
}