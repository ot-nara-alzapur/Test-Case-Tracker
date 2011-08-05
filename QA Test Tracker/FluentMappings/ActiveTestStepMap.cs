using FluentNHibernate.Mapping;
using QA_Test_Tracker.Models;

namespace QA_Test_Tracker.FluentMappings
{
    public class ActiveTestStepMap : ClassMap<ActiveTestStep>
    {
        public ActiveTestStepMap()
        {
            Id(x => x.ID);
            Map(x => x.RequestTicketNumber);
            Map(x => x.Status);
            References(x => x.Test)
                .ForeignKey("FK_ActiveTestSteps_TestSteps");
        }
    }
}