using System.Linq;
using System.Web.Mvc;
using QA_Test_Tracker.Configuration;
using QA_Test_Tracker.Models;
using Siege.Repository;

namespace QA_Test_Tracker.Controllers
{   
    public class TestStepsController : Controller
    {
        private readonly IRepository<TestTrackerDatabase> repository;

        public TestStepsController(IRepository<TestTrackerDatabase> repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Query<TestStep>().Find());
        }

        public ViewResult Details(int id)
        {
            var teststep = repository.Query<TestStep>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(teststep);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(TestStep teststep)
        {
            if (ModelState.IsValid)
            {
                repository.Save(teststep);
                return RedirectToAction("Index");  
            }

            return View(teststep);
        }
        
        public ActionResult Edit(int id)
        {
            var teststep = repository.Query<TestStep>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(teststep);
        }

        [HttpPost]
        public ActionResult Edit(TestStep teststep)
        {
            if (ModelState.IsValid)
            {
                repository.Save(teststep);
                return RedirectToAction("Index");
            }
            return View(teststep);
        }

        public ActionResult Delete(int id)
        {
            var teststep = repository.Query<TestStep>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(teststep);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var teststep = repository.Query<TestStep>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            repository.Delete(teststep);
            return RedirectToAction("Index");
        }
    }
}