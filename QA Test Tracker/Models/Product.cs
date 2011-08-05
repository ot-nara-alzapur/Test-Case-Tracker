using System.ComponentModel.DataAnnotations;

namespace QA_Test_Tracker.Models
{
    public class Product
    {
        public virtual int ID { get; set; }
        [Required] public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}