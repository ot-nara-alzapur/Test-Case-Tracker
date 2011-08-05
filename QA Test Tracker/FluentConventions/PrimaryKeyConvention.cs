using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace QA_Test_Tracker.FluentConventions
{
    public class PrimaryKeyIdConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column(instance.EntityType.Name + "ID");
        }
    }
}