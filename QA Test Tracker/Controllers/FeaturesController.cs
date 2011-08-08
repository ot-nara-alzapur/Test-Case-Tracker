using System.Linq;
using System.Web.Mvc;
using QA_Test_Tracker.Configuration;
using QA_Test_Tracker.Models;
using Siege.Repository;

namespace QA_Test_Tracker.Controllers
{   
    public class FeaturesController : Controller
    {
        private readonly IRepository<TestTrackerDatabase> repository;

        public FeaturesController(IRepository<TestTrackerDatabase> repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Query<Feature>().Find());
        }

        public ViewResult Details(int id)
        {
            var feature = repository.Query<Feature>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(feature);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(Feature feature)
        {
            if (ModelState.IsValid)
            {
                repository.Save(feature);
                return RedirectToAction("Index");  
            }

            return View(feature);
        }
        
        public ActionResult Edit(int id)
        {
            var feature = repository.Query<Feature>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(feature);
        }

        [HttpPost]
        public ActionResult Edit(Feature feature)
        {
            if (ModelState.IsValid)
            {
                repository.Save(feature);
                return RedirectToAction("Index");
            }
            return View(feature);
        }

        public ActionResult Delete(int id)
        {
            var feature = repository.Query<Feature>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(feature);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var feature = repository.Query<Feature>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            repository.Delete(feature);
            return RedirectToAction("Index");
        }
    }
}