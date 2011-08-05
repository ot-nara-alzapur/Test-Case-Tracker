using System.Collections.Generic;

namespace QA_Test_Tracker.Models
{
    public class ActiveTestPlan
    {
        public virtual int ID { get; set; }
        public virtual TestPlan TestPlan { get; set; }
        public virtual List<ActiveTestCase> TestCases { get; set; }
        public virtual List<Build> Builds { get; set; }
        public virtual string RequestTicketNumber { get; set; }
    }
}