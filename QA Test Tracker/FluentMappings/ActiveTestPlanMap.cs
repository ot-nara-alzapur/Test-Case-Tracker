using FluentNHibernate.Mapping;
using QA_Test_Tracker.Models;

namespace QA_Test_Tracker.FluentMappings
{
    public class ActiveTestPlanMap : ClassMap<ActiveTestPlan>
    {
        public ActiveTestPlanMap()
        {
            Id(x => x.ID);
            References(x => x.Build).Cascade.None();
            HasMany(x => x.TestCases)
                .Cascade.All()
                .ForeignKeyConstraintName("FK_ActiveTestCases_ActiveTestPlans")
                .Inverse();
            References(x => x.TestPlan)
                .ForeignKey("FK_ActiveTestPlans_TestPlans");
        }
    }
}