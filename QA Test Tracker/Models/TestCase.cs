using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QA_Test_Tracker.Models
{
    public class TestCase : DomainObject
    {
        [Required]
        public virtual TestComponent Component { get; set; }
        public virtual List<TestStep> Tests { get; set; }
    }
}