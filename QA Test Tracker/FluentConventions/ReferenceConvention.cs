using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace QA_Test_Tracker.FluentConventions
{
    public class ReferenceConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.Column(instance.Property.Name + "ID");
            instance.ForeignKey(string.Format("FK_{0}_{1}_{2}",
                                              instance.EntityType.Name + "s",
                                              instance.Property.Name + "s",
                                              instance.Property.Name + "ID"));
        }
    }
}