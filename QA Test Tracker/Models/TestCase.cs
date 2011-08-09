using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QA_Test_Tracker.Models
{
    public class TestCase : DomainObject
    {
        [Required]
        public virtual string Name { get; set; }
        public virtual TestComponent Component { get; set; }
        public virtual IList<TestStep> Tests { get; set; }

        public TestCase()
        {
            this.Tests = new List<TestStep>();
        }
    }
}