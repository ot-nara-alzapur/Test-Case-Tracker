using System.Collections.Generic;

namespace QA_Test_Tracker.Models
{
    public class ActiveTestPlan : DomainObject
    {
        public virtual TestPlan TestPlan { get; set; }
        public virtual List<ActiveTestCase> TestCases { get; set; }
        public virtual string RequestTicketNumber { get; set; }
    }
}