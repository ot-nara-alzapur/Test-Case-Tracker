using System.Linq;
using System.Web.Mvc;
using QA_Test_Tracker.Configuration;
using QA_Test_Tracker.Models;
using Siege.Repository;

namespace QA_Test_Tracker.Controllers
{   
    public class ReleasesController : Controller
    {
        private readonly IRepository<TestTrackerDatabase> repository;

        public ReleasesController(IRepository<TestTrackerDatabase> repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Query<Release>().Find());
        }

        public ViewResult Details(int id)
        {
            var release = repository.Query<Release>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(release);
        }

        public ActionResult Create()
        {
            return View();
        } 
        
        [HttpPost]
        public ActionResult Create(Release release)
        {
            if (ModelState.IsValid)
            {
                repository.Save(release);
                return RedirectToAction("Index");  
            }

            return View(release);
        }
        
        public ActionResult Edit(int id)
        {
            var release = repository.Query<Release>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(release);
        }

        [HttpPost]
        public ActionResult Edit(Release release)
        {
            if (ModelState.IsValid)
            {
                repository.Save(release);
                return RedirectToAction("Index");
            }
            return View(release);
        }

        public ActionResult Delete(int id)
        {
            var release = repository.Query<Release>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(release);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var release = repository.Query<Release>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            repository.Delete(release);
            return RedirectToAction("Index");
        }
    }
}