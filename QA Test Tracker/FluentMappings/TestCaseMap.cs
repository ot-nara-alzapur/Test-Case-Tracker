using FluentNHibernate.Mapping;
using QA_Test_Tracker.Models;

namespace QA_Test_Tracker.FluentMappings
{
    public class TestCaseMap : ClassMap<TestCase>
    {
        public TestCaseMap()
        {
            Id(x => x.ID);
            References(x => x.Component)
                .ForeignKey("FK_TestCases_TestComponents");
            HasMany(x => x.Tests)
                .ForeignKeyConstraintName("FK_TestSteps_TestCases")
                .Inverse();
        }
    }
}