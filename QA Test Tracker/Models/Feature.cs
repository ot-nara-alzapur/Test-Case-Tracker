using System.ComponentModel.DataAnnotations;

namespace QA_Test_Tracker.Models
{
    public class Feature : DomainObject
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public virtual string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }
    }
}