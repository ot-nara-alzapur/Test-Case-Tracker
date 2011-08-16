using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QA_Test_Tracker.Models
{
    public class TestCase : DomainObject
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public virtual string Name { get; set; }
        public virtual TestPlan TestPlan { get; set; }
        public virtual TestComponent TestComponent { get; set; }
        public virtual IList<TestStep> Tests { get; set; }

        public TestCase()
        {
            this.Tests = new List<TestStep>();
        }

        public virtual void Add(TestStep testStep)
        {
            testStep.TestCase = this;
            this.Tests.Add(testStep);
        }
    }
}