using System.Linq;
using System.Web.Mvc;
using QA_Test_Tracker.Configuration;
using QA_Test_Tracker.Models;
using Siege.Repository;

namespace QA_Test_Tracker.Controllers
{   
    public class TestPlansController : Controller
    {
        private readonly IRepository<TestTrackerDatabase> repository;

        public TestPlansController(IRepository<TestTrackerDatabase> repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Query<TestPlan>().Find());
        }

        public ViewResult Details(int id)
        {
            var testplan = repository.Query<TestPlan>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(testplan);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(TestPlan testplan)
        {
            if (ModelState.IsValid)
            {
                repository.Save(testplan);
                return RedirectToAction("Index");  
            }

            return View(testplan);
        }
        
        public ActionResult Edit(int id)
        {
            var testplan = repository.Query<TestPlan>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();

            return View(testplan);
        }

        [HttpPost]
        public ActionResult Edit(TestPlan testplan)
        {
            if (ModelState.IsValid)
            {
                repository.Save(testplan);
                return RedirectToAction("Index");
            }

            return View(testplan);
        }

        public ActionResult Delete(int id)
        {
            var testplan = repository.Query<TestPlan>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(testplan);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var testplan = repository.Query<TestPlan>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            repository.Delete(testplan);
            return RedirectToAction("Index");
        }
    }
}