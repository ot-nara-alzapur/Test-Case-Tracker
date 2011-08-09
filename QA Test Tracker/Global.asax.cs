using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using QA_Test_Tracker.Configuration;
using QA_Test_Tracker.Controllers;
using QA_Test_Tracker.Models;
using QA_Test_Tracker.Views;
using Siege.Repository;
using Siege.Repository.NHibernate;
using Siege.Repository.UnitOfWork;
using Siege.ServiceLocator;
using Siege.ServiceLocator.Extensions.Conventions;
using Siege.ServiceLocator.Extensions.ExtendedRegistrationSyntax;
using Siege.ServiceLocator.Native;
using Siege.ServiceLocator.Registrations.Default;
using Siege.ServiceLocator.Web;
using Siege.ServiceLocator.Web.Conventions;

namespace QA_Test_Tracker
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        protected IServiceLocatorAdapter GetServiceLocatorAdapter()
        {
            return new SiegeAdapter();
        }
        
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }

        void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            var serviceLocator = new HttpServiceLocator(GetServiceLocatorAdapter(), new HttpSessionStore(new SessionWrapper(() => HttpContext.Current.Session)));

            serviceLocator
                .Register(Given<ModelValidatorProvider>.Then(ModelValidatorProviders.Providers[0]))
                .Register(Given<IViewEngine>.Then<WebFormViewEngine>())
                .Register(Given<IViewPageActivator>.Then<SiegeViewActivator>())
                .Register(Given<IFilterProvider>.Then<NullFilterProvider>())
                .Register(Given<IControllerFactory>.Then<ServiceLocatorControllerFactory>())
                .Register(Given<RepositoryViewPage<TestPlan, TestTrackerDatabase>>.Then<RepositoryViewPage<TestPlan, TestTrackerDatabase>>())
                .Register(Using.Convention<ControllerConvention<HomeController>>())
                .Register(Using.Convention(new NHibernateConvention<SingletonUnitOfWorkStore, TestTrackerDatabase>(TestTracker.SessionFactory)));

            ModelBinders.Binders.DefaultBinder = new RepositoryModelBinder(serviceLocator);
            DependencyResolver.SetResolver(serviceLocator.GetInstance, t => new[] { serviceLocator.GetInstance(t) });
        }
    }

    public class SiegeViewActivator : IViewPageActivator 
    {
        private readonly IServiceLocator locator;

        public SiegeViewActivator(IServiceLocator locator)
        {
            this.locator = locator;
        }

        public object Create(ControllerContext controllerContext, Type type)
        {
            if (locator.HasTypeRegistered(type))
            {
                return locator.GetInstance(type);
            }
            
            if (typeof(IRepositoryViewPage).IsAssignableFrom(type))
            {
                var registration = new DefaultRegistration<IRepositoryViewPage>();
                registration.MapsTo(type);

                locator.Register(registration);
                return locator.GetInstance(type);
            }

            return type.GetConstructor(new Type[] {}).Invoke(new object[] {});
        }
    }

    public class NullFilterProvider : IFilterProvider
    {
        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            return new List<Filter>();
        }
    }
    
    public class SingletonUnitOfWorkStore : IUnitOfWorkStore
    {
        private IUnitOfWork unitOfWork;

        public void Dispose()
        {
            
        }

        public IUnitOfWork CurrentFor<TDatabase>() where TDatabase : IDatabase
        {
            return this.unitOfWork;
        }

        public void SetUnitOfWork<TDatabase>(IUnitOfWork unitOfWork) where TDatabase : IDatabase
        {
            this.unitOfWork = unitOfWork;
        }
    }
}