using System.Collections.Generic;
using System.Web.Mvc;
using QA_Test_Tracker.Models;
using Siege.Repository;

namespace QA_Test_Tracker.Views
{
    public interface IRepositoryViewPage
    {
        IList<T> GetAll<T>() where T : DomainObject;
    }

    public class RepositoryViewPage<TModel, TDatabase> : ViewPage<TModel>, IRepositoryViewPage where TDatabase : IDatabase
    {
        private readonly IRepository<TDatabase> repository;

        public RepositoryViewPage() {}

        public RepositoryViewPage(IRepository<TDatabase> repository)
        {
            this.repository = repository;
        }

        public IList<T> GetAll<T>() where T : DomainObject
        {
            return repository.Query<T>().Find();
        }
    }
}