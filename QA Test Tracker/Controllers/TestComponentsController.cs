using System.Linq;
using System.Web.Mvc;
using QA_Test_Tracker.Configuration;
using QA_Test_Tracker.Models;
using Siege.Repository;

namespace QA_Test_Tracker.Controllers
{   
    public class TestComponentsController : Controller
    {
        private readonly IRepository<TestTrackerDatabase> repository;

        public TestComponentsController(IRepository<TestTrackerDatabase> repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Query<TestComponent>().Find());
        }

        public ViewResult Details(int id)
        {
            var testcomponent = repository.Query<TestComponent>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(testcomponent);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(TestComponent testcomponent)
        {
            if (ModelState.IsValid)
            {
                repository.Save(testcomponent);
                return RedirectToAction("Index");  
            }

            return View(testcomponent);
        }
        
        public ActionResult Edit(int id)
        {
            var testcomponent = repository.Query<TestComponent>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(testcomponent);
        }

        [HttpPost]
        public ActionResult Edit(TestComponent testcomponent)
        {
            if (ModelState.IsValid)
            {
                repository.Save(testcomponent);
                return RedirectToAction("Index");
            }
            return View(testcomponent);
        }

        public ActionResult Delete(int id)
        {
            var testcomponent = repository.Query<TestComponent>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(testcomponent);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var testcomponent = repository.Query<TestComponent>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            repository.Delete(testcomponent);
            return RedirectToAction("Index");
        }
    }
}