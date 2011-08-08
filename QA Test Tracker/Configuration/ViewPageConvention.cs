using System.Web.Mvc;
using Siege.ServiceLocator.Extensions.AutoScanner;

namespace QA_Test_Tracker.Configuration
{
    public class ViewPageConvention<TViewPage> : AutoScanningConvention
    {
        public ViewPageConvention()
        {
            FromAssemblyContaining<TViewPage>();
            ForTypesImplementing<ViewPage>();
        }
    }
}