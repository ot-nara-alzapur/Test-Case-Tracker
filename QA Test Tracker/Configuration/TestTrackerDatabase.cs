using Siege.Repository;
using Siege.Repository.UnitOfWork;

namespace QA_Test_Tracker.Configuration
{
    public class TestTrackerDatabase : Database<TestTrackerDatabase>
    {
        public TestTrackerDatabase(IUnitOfWorkFactory<TestTrackerDatabase> unitOfWorkFactory, IUnitOfWorkStore unitOfWorkStore) : base(unitOfWorkFactory, unitOfWorkStore)
        {
        }
    }
}