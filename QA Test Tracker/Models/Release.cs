using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QA_Test_Tracker.Models
{
    public class Release : DomainObject
    {
        [Required]
        public virtual DateTime ReleaseDate { get; set; }
        [Required]
        public virtual string ReleaseTicketNumber { get; set; }
        public virtual IList<Build> Builds { get; set; }

        public Release()
        {
            this.Builds = new List<Build>();
        }

        public virtual void Add(Build build)
        {
            build.Release = this;
            this.Builds.Add(build);
        }
    }
}