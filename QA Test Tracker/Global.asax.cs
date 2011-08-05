using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using QA_Test_Tracker.Configuration;
using QA_Test_Tracker.Controllers;
using Siege.Repository.NHibernate;
using Siege.Repository.Web;
using Siege.ServiceLocator;
using Siege.ServiceLocator.Extensions.Conventions;
using Siege.ServiceLocator.Extensions.ExtendedRegistrationSyntax;
using Siege.ServiceLocator.Native;
using Siege.ServiceLocator.Web;
using Siege.ServiceLocator.Web.Conventions;
using SessionWrapper = Siege.Repository.Web.SessionWrapper;

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
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
                );
        }

        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);

            ServiceLocator
                .Register(Given<HttpUnitOfWorkStore>.Then(new HttpUnitOfWorkStore(new SessionWrapper(() => HttpContext.Current.Session))))
                .Register(Using.Convention<ControllerConvention<HomeController>>())
                .Register(Using.Convention(new NHibernateConvention<HttpUnitOfWorkStore, TestTrackerDatabase>(TestTracker.SessionFactory)));

        }

        void Session_Start(object sender, EventArgs e)
        {
            Session["lol!"] = 1;
        }
    }
}