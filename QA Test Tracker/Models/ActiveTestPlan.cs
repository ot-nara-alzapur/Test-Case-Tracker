using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QA_Test_Tracker.Models
{
    public class ActiveTestPlan : DomainObject
    {
        public virtual TestPlan TestPlan { get; set; }
        public virtual List<ActiveTestCase> TestCases { get; set; }
        public virtual List<Build> Builds { get; set; }
        [Required]
        public virtual string RequestTicketNumber { get; set; }
        [Required]
        public virtual Release Release { get; set; }
    }
}