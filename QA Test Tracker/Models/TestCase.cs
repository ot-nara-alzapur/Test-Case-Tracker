using System.Collections.Generic;

namespace QA_Test_Tracker.Models
{
    public class TestCase
    {
        public virtual int ID { get; set; }
        public virtual TestComponent Component { get; set; }
        public virtual List<TestStep> Tests { get; set; }
    }
}