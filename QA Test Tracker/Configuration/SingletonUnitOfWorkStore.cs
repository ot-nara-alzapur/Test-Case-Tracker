using Siege.Repository;
using Siege.Repository.UnitOfWork;

namespace QA_Test_Tracker.Configuration
{
    public class SingletonUnitOfWorkStore : IUnitOfWorkStore
    {
        private IUnitOfWork unitOfWork;

        #region IUnitOfWorkStore Members

        public void Dispose()
        {
        }

        public IUnitOfWork CurrentFor<TDatabase>() where TDatabase : IDatabase
        {
            return unitOfWork;
        }

        public void SetUnitOfWork<TDatabase>(IUnitOfWork unitOfWork) where TDatabase : IDatabase
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion
    }
}