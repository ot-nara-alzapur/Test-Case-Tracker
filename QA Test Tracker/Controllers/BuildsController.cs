using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QA_Test_Tracker.Configuration;
using QA_Test_Tracker.Models;
using Siege.Repository;

namespace QA_Test_Tracker.Controllers
{   
    public class BuildsController : Controller
    {
        private readonly IRepository<TestTrackerDatabase> repository;

        public BuildsController(IRepository<TestTrackerDatabase> repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Query<Build>().Find());
        }

        public ViewResult Details(int id)
        {
            var build = repository.Query<Build>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(build);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(Build build)
        {
            if (ModelState.IsValid)
            {
                repository.Save(build);
                return RedirectToAction("Index");  
            }

            return View(build);
        }
        
        public ActionResult Edit(int id)
        {
            var build = repository.Query<Build>(query => query.Where(x => x.ID == id)).FindFirstOrDefault(); 
            return View(build);
        }

        [HttpPost]
        public ActionResult Edit(Build build)
        {
            if (ModelState.IsValid)
            {
                repository.Save(build);
                return RedirectToAction("Index");
            }
            return View(build);
        }

        public ActionResult Delete(int id)
        {
            var build = repository.Query<Build>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(build);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var build = repository.Query<Build>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            repository.Delete(build);
            return RedirectToAction("Index");
        }
    }
}