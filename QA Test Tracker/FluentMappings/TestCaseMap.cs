using FluentNHibernate.Mapping;
using QA_Test_Tracker.Models;

namespace QA_Test_Tracker.FluentMappings
{
    public class TestCaseMap : ClassMap<TestCase>
    {
        public TestCaseMap()
        {
            Id(x => x.ID);
            Map(x => x.Name);
            References(x => x.TestPlan).Cascade.None();
            References(x => x.TestComponent)
                .ForeignKey("FK_TestCases_TestComponents");
            HasMany(x => x.Tests)
                .ForeignKeyConstraintName("FK_TestSteps_TestCases")
                .Cascade.All()
                .Inverse();
        }
    }
}