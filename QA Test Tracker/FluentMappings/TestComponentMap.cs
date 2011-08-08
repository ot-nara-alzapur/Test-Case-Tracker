using FluentNHibernate.Mapping;
using QA_Test_Tracker.Models;

namespace QA_Test_Tracker.FluentMappings
{
    public class TestComponentMap : ClassMap<TestComponent>
    {
        public TestComponentMap()
        {
            Id(x => x.ID);
            Map(x => x.Name);
            Map(x => x.Description);
            References(x => x.Product)
                .ForeignKey("FK_TestComponents_Products");
        }
    }
}