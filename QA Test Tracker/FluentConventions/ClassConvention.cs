using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace QA_Test_Tracker.FluentConventions
{
    public class ClassConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table(instance.EntityType.Name + "s");
        }
    }
}