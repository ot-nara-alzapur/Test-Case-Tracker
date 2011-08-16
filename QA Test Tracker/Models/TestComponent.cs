using System.ComponentModel.DataAnnotations;

namespace QA_Test_Tracker.Models
{
    public class TestComponent : DomainObject
    {
        public virtual Product Product { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public virtual string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }
    }
}