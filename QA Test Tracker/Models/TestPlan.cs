using System.Collections.Generic;

namespace QA_Test_Tracker.Models
{
    public class TestPlan : DomainObject
    {
        public virtual string Name { get; set; }
        public virtual Feature Feature { get; set; }
        public virtual IList<TestCase> TestCases { get; set; }

        public TestPlan()
        {
            this.TestCases = new List<TestCase>();
        }

        public virtual void Add(TestCase testCase)
        {
            this.TestCases.Add(testCase);
        }
    }
}