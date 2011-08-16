using System.Web.Mvc;
using System.Web.Routing;
using QA_Test_Tracker.Configuration;
using QA_Test_Tracker.Controllers;
using QA_Test_Tracker.Models;
using Siege.Repository;
using Siege.Repository.NHibernate;
using Siege.ServiceLocator;
using Siege.ServiceLocator.Extensions.Conventions;
using Siege.ServiceLocator.Extensions.ExtendedRegistrationSyntax;
using Siege.ServiceLocator.Native;
using Siege.ServiceLocator.Web;
using Siege.ServiceLocator.Web.Conventions;

namespace QA_Test_Tracker
{
    public class MvcApplication : ServiceLocatorHttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        protected override IServiceLocatorAdapter GetServiceLocatorAdapter()
        {
            return new SiegeAdapter();
        }

        protected override IControllerFactory GetControllerFactory()
        {
            return new GenericServiceLocatorControllerFactory(this.ServiceLocator);
        }

        public override void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }

        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);

            ServiceLocator
                .Register(Using.Convention<ControllerConvention<HomeController>>())
                .Register(Given<GenericController<TestCase>>.Then<TestCaseController>())
                .Register(Given<GenericController<TestStep>>.Then<TestStepController>())
                .Register(Given<GenericController<Build>>.Then<BuildController>())
                .Register(Using.Convention(new NHibernateConvention<SingletonUnitOfWorkStore, TestTrackerDatabase>(TestTracker.SessionFactory)));

            var repository = ServiceLocator.GetInstance<IRepository<TestTrackerDatabase>>();

            ModelBinders.Binders.Add(typeof(Build), new RepositoryModelBinder<Build>(repository));
            ModelBinders.Binders.Add(typeof(Feature), new RepositoryModelBinder<Feature>(repository));
            ModelBinders.Binders.Add(typeof(Product), new RepositoryModelBinder<Product>(repository));
            ModelBinders.Binders.Add(typeof(Release), new RepositoryModelBinder<Release>(repository));
            ModelBinders.Binders.Add(typeof(TestCase), new RepositoryModelBinder<TestCase>(repository));
            ModelBinders.Binders.Add(typeof(TestPlan), new RepositoryModelBinder<TestPlan>(repository));
            ModelBinders.Binders.Add(typeof(TestComponent), new RepositoryModelBinder<TestComponent>(repository));
            ModelBinders.Binders.Add(typeof(TestStep), new RepositoryModelBinder<TestStep>(repository));
            ModelBinders.Binders.Add(typeof(ActiveTestCase), new RepositoryModelBinder<ActiveTestCase>(repository));
            ModelBinders.Binders.Add(typeof(ActiveTestPlan), new RepositoryModelBinder<ActiveTestPlan>(repository));
            ModelBinders.Binders.Add(typeof(ActiveTestStep), new RepositoryModelBinder<ActiveTestStep>(repository));
            
            StaticServiceLocator.Current = this.ServiceLocator;
        }
    }
}