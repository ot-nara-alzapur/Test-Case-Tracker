using FluentNHibernate.Mapping;
using QA_Test_Tracker.Models;

namespace QA_Test_Tracker.FluentMappings
{
    public class ActiveTestCaseMap : ClassMap<ActiveTestCase>
    {
        public ActiveTestCaseMap()
        {
            Id(x => x.ID);
            References(x => x.TestCase)
                .ForeignKey("FK_ActiveTestCases_TestCases");
            HasMany(x => x.Tests)
                .ForeignKeyConstraintName("FK_ActiveTestSteps_ActiveTestCases")
                .Inverse();
        }
    }
}