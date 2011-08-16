using System.ComponentModel.DataAnnotations;

namespace QA_Test_Tracker.Models
{
    public class TestStep : DomainObject
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public virtual string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }
        public virtual TestCase TestCase { get; set; }
    }
}