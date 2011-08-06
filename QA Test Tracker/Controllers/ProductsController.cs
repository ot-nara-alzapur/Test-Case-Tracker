using System.Linq;
using System.Web.Mvc;
using QA_Test_Tracker.Configuration;
using QA_Test_Tracker.Models;
using Siege.Repository;

namespace QA_Test_Tracker.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IRepository<TestTrackerDatabase> repository;

        public ProductsController(IRepository<TestTrackerDatabase> repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Query<Product>().Find());
        }

        public ViewResult Details(int id)
        {
            var product = repository.Query<Product>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.Save(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public ActionResult Edit(int id)
        {
            var product = repository.Query<Product>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.Save(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            var product = repository.Query<Product>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = repository.Query<Product>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            repository.Delete(product);
            return RedirectToAction("Index");
        }
    }
}