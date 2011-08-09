using System.Linq;
using System.Web.Mvc;
using QA_Test_Tracker.Configuration;
using QA_Test_Tracker.Models;
using Siege.Repository;

namespace QA_Test_Tracker.Controllers
{
    public class GenericController<TModel> : Controller where TModel : DomainObject
    {
        protected readonly IRepository<TestTrackerDatabase> repository;

        public GenericController(IRepository<TestTrackerDatabase> repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Query<TModel>().Find());
        }

        public ViewResult Details(int id)
        {
            var item = repository.Query<TModel>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(item);
        }

        public ActionResult Create(int? id)
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(TModel item)
        {
            if (ModelState.IsValid)
            {
                repository.Save(item);

                return RedirectToAction("Index");  
            }

            return View(item);
        }
        
        public ActionResult Edit(int id)
        {
            var item = repository.Query<TModel>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(TModel item)
        {
            if (ModelState.IsValid)
            {
                repository.Save(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        public ActionResult Delete(int id)
        {
            var item = repository.Query<TModel>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var item = repository.Query<TModel>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            repository.Delete(item);
            return RedirectToAction("Index");
        }
    }
}