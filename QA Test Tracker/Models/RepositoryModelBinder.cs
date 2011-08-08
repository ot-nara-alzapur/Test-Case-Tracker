using System;
using QA_Test_Tracker.Configuration;
using Siege.Repository.NHibernate;
using Siege.ServiceLocator;
using Siege.ServiceLocator.Web;

namespace QA_Test_Tracker.Models
{
    public class RepositoryModelBinder : ServiceLocatorModelBinder
    {
        private readonly IServiceLocator serviceLocator;

        public RepositoryModelBinder(IServiceLocator serviceLocator) : base(serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        protected override object CreateModel(System.Web.Mvc.ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext, Type modelType)
        {
            if (!typeof(DomainObject).IsAssignableFrom(modelType)) return base.CreateModel(controllerContext, bindingContext, modelType);

            var unitOfWorkManager = serviceLocator.GetInstance<NHibernateUnitOfWorkManager>();

            var session = unitOfWorkManager.SessionFor<TestTrackerDatabase>();

            var result = bindingContext.ValueProvider.GetValue("ID");
            if (result != null && Convert.ToInt32(result.AttemptedValue) != 0) return session.Get(modelType, Convert.ToInt32(result.AttemptedValue));
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }
    }
}