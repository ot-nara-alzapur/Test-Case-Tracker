namespace QA_Test_Tracker.Models
{
    public class ActiveTestStep
    {
        public virtual int ID { get; set; }
        public virtual TestStep Test { get; set; }
        public virtual TestStatus Status { get; set; }
        public virtual string RequestTicketNumber { get; set; }
    }
}