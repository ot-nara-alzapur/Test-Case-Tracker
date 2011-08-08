using System.ComponentModel.DataAnnotations;

namespace QA_Test_Tracker.Models
{
    public class TestComponent : DomainObject
    {
        [Required] 
        public virtual Product Product { get; set; }
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string Description { get; set; }
    }
}