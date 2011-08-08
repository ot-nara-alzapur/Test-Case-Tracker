using System;
using System.Web.Mvc;
using System.Web.Routing;
using QA_Test_Tracker.Configuration;
using QA_Test_Tracker.Controllers;
using QA_Test_Tracker.Models;
using Siege.Repository;
using Siege.Repository.NHibernate;
using Siege.Repository.UnitOfWork;
using Siege.ServiceLocator;
using Siege.ServiceLocator.Extensions.Conventions;
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
                .Register(Using.Convention(new NHibernateConvention<SingletonUnitOfWorkStore, TestTrackerDatabase>(TestTracker.SessionFactory)));

            ModelBinders.Binders.Clear();
            ModelBinders.Binders.DefaultBinder = new RepositoryModelBinder(ServiceLocator);
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