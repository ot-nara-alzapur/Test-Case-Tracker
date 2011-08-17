using System.ComponentModel.DataAnnotations;

namespace QA_Test_Tracker.Models
{
    public class ActiveTestStep : DomainObject
    {
        public virtual TestStep Test { get; set; }
        [Required]
        public virtual TestStatus Status { get; set; }
        public virtual string RequestTicketNumber { get; set; }
        public virtual ActiveTestCase ActiveTestCase { get; set; }
    }
}