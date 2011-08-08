using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;

namespace QA_Test_Tracker.FluentConventions
{
    public class ForeignKeyNameConvention : ForeignKeyConvention
    {
        protected override string GetKeyName(Member property, Type type)
        {
            if (property == null)
                return type.Name + "ID";

            return property.Name + "ID";
        }
    }
}