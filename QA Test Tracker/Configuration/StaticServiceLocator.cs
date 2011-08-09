using Siege.ServiceLocator;

namespace QA_Test_Tracker.Configuration
{
    public static class StaticServiceLocator
    {
        public static IServiceLocator Current { get; set; }
    }
}