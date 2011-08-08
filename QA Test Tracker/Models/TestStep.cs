using System.ComponentModel.DataAnnotations;

namespace QA_Test_Tracker.Models
{
    public class TestStep : DomainObject
    {
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string Description { get; set; }
    }
}