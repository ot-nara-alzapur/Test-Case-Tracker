using System.Collections.Generic;

namespace QA_Test_Tracker.Models
{
    public class Build : DomainObject
    {
        public virtual Product Product { get; set; }
        public virtual string BuildNumber { get; set; }
        public virtual IList<ActiveTestPlan> TestPlans { get; set; }
        public virtual Release Release { get; set; }
        public virtual BuildStatus Status { get; set; }

        public Build()
        {
            this.TestPlans = new List<ActiveTestPlan>();
        }
    }
}