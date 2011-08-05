using System.Collections.Generic;

namespace QA_Test_Tracker.Models
{
    public class ActiveTestCase
    {
        public virtual int ID { get; set; }
        public virtual TestCase TestCase { get; set; }
        public virtual List<ActiveTestStep> Tests { get; set; }
    }
}