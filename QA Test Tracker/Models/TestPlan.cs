using System.Collections.Generic;

namespace QA_Test_Tracker.Models
{
    public class TestPlan
    {
        public virtual int ID { get; set; }
        public virtual Feature Feature { get; set; }
        public virtual List<TestCase> TestCases { get; set; }
    }
}