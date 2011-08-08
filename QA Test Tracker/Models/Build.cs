using System.ComponentModel.DataAnnotations;

namespace QA_Test_Tracker.Models
{
    public class Build : DomainObject
    {
        [Required]
        public virtual Product Product { get; set; }
        [Required]
        public virtual string BuildNumber { get; set; }
    }
}