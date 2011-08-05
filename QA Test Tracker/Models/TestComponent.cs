namespace QA_Test_Tracker.Models
{
    public class TestComponent
    {
        public virtual int ID { get; set; }
        public virtual Product Product { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}