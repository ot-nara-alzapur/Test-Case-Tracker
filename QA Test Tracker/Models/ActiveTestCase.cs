using System.Collections.Generic;

namespace QA_Test_Tracker.Models
{
    public class ActiveTestCase : DomainObject
    {
        public virtual TestCase TestCase { get; set; }
        public virtual IList<ActiveTestStep> Tests { get; set; }
        public virtual ActiveTestPlan ActiveTestPlan { get; set; }

        public ActiveTestCase()
        {
            this.Tests = new List<ActiveTestStep>();
        }

        public virtual void Add(ActiveTestStep test)
        {
            test.ActiveTestCase = this;
            this.Tests.Add(test);
        }
    }
}