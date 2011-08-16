using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QA_Test_Tracker.Models
{
    public class TestPlan : DomainObject
    {
        [DataType(DataType.MultilineText)]
        public virtual string Name { get; set; }
        public virtual Feature Feature { get; set; }
        public virtual IList<TestCase> TestCases { get; set; }

        public TestPlan()
        {
            this.TestCases = new List<TestCase>();
        }

        public virtual void Add(TestCase testCase)
        {
            testCase.TestPlan = this;
            this.TestCases.Add(testCase);
        }
    }
}