using System;
using System.Linq;
using System.Web.Mvc;
using QA_Test_Tracker.Configuration;
using Siege.Repository;

namespace QA_Test_Tracker.Models
{
    public class RepositoryModelBinder<T> : DefaultModelBinder where T : DomainObject
    {
        private readonly IRepository<TestTrackerDatabase> repository;

        public RepositoryModelBinder(IRepository<TestTrackerDatabase> repository)
        {
            this.repository = repository;
        }

        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            if (modelType != typeof (T)) return base.CreateModel(controllerContext, bindingContext, modelType);

            var result = bindingContext.ValueProvider.GetValue(typeof(T).Name + ".ID");
            if (result == null) bindingContext.ValueProvider.GetValue("ID");
            if (result != null && Convert.ToInt32(result.AttemptedValue) != 0)
            {
                return repository.Query<T>(query => query.Where(x => x.ID == Convert.ToInt32(result.AttemptedValue))).FindFirstOrDefault();
            }

            return base.CreateModel(controllerContext, bindingContext, modelType);
        }
    }
}