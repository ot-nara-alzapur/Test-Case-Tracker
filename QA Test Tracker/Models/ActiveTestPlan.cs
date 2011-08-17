using System.Collections.Generic;

namespace QA_Test_Tracker.Models
{
    public class ActiveTestPlan : DomainObject
    {
        public virtual TestPlan TestPlan { get; set; }
        public virtual IList<ActiveTestCase> TestCases { get; set; }
        public virtual Build Build { get; set; }

        public ActiveTestPlan()
        {
            this.TestCases = new List<ActiveTestCase>();
        }

        public virtual void Add(ActiveTestCase testCase)
        {
            testCase.ActiveTestPlan = this;
            this.TestCases.Add(testCase);
        }
    }
}