namespace QA_Test_Tracker.Models
{
    public class Build
    {
        public virtual int ID { get; set; }
        public virtual Product Product { get; set; }
        public virtual string BuildNumber { get; set; }
    }
}