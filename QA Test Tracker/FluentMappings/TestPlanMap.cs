using FluentNHibernate.Mapping;
using QA_Test_Tracker.Models;

namespace QA_Test_Tracker.FluentMappings
{
    public class TestPlanMap : ClassMap<TestPlan>
    {
        public TestPlanMap()
        {
            Id(x => x.ID);
            Cache.ReadWrite();
            References(x => x.Feature)
                .ForeignKey("FK_TestPlans_Features");
            HasMany(x => x.TestCases)
                .ForeignKeyConstraintName("FK_TestCases_TestPlans")
                .Inverse();
        }
    }
}