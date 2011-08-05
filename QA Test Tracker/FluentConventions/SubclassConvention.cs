using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace QA_Test_Tracker.FluentConventions
{
    public class SubclassConvention : IJoinedSubclassConvention
    {
        public void Apply(IJoinedSubclassInstance instance)
        {
            instance.Table(instance.EntityType.Name + "s");
            instance.Key.Column(instance.EntityType.BaseType.Name + "ID");
        }
    }
}