using FluentNHibernate.Mapping;
using QA_Test_Tracker.Models;

namespace QA_Test_Tracker.FluentMappings
{
    public class ReleaseMap : ClassMap<Release>
    {
        public ReleaseMap()
        {
            Id(x => x.ID);
            Map(x => x.ReleaseDate);
            Map(x => x.ReleaseTicketNumber);
            HasMany(x => x.Builds)
                .ForeignKeyConstraintName("FK_Releases_Builds")
                .Cascade.All()
                .Inverse();
        }
    }
}