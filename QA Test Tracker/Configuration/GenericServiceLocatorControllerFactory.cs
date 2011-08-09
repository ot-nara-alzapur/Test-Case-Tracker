using System;
using System.Web.Mvc;
using System.Web.Routing;
using QA_Test_Tracker.Controllers;
using Siege.ServiceLocator;
using Siege.ServiceLocator.Web;

namespace QA_Test_Tracker.Configuration
{
    public class GenericServiceLocatorControllerFactory : ServiceLocatorControllerFactory
    {
        private readonly IServiceLocator locator;

        public GenericServiceLocatorControllerFactory(IServiceLocator locator) : base(locator)
        {
            this.locator = locator;
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (Type.GetType("QA_Test_Tracker.Models." + controllerName) == null) return base.CreateController(requestContext, controllerName);
            var controllerType = typeof(GenericController<>).MakeGenericType(Type.GetType("QA_Test_Tracker.Models." + controllerName));

            return locator.GetInstance<ControllerBase>(controllerType);
        }
    }
}