using System;
using System.ComponentModel.DataAnnotations;

namespace QA_Test_Tracker.Models
{
    public class Release : DomainObject
    {
        [Required]
        public virtual DateTime ReleaseDate { get; set; }
        [Required]
        public virtual string ReleaseTicketNumber { get; set; }
    }
}