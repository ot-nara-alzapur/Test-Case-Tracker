using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QA_Test_Tracker.Models
{
    public class TestPlan : DomainObject
    {
        [Required] 
        public virtual Feature Feature { get; set; }
        public virtual List<TestCase> TestCases { get; set; }
    }
}