using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using QA_Test_Tracker.Configuration;
using QA_Test_Tracker.Models;
using Siege.Repository;

namespace QA_Test_Tracker.Controllers
{   
    public class TestCasesController : Controller
    {
        private readonly IRepository<TestTrackerDatabase> repository;

        public TestCasesController(IRepository<TestTrackerDatabase> repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Query<TestCase>().Find());
        }

        public ViewResult Details(int id)
        {
            var testcase = repository.Query<TestCase>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(testcase);
        }

        public ActionResult Create(int? testPlanID)
        {
            return View();
        }

        public JsonResult List(int? testPlanID)
        {
            int id = Convert.ToInt32(Request.QueryString["testPlanID"]);
            if (id == 0) return Json(new {});
            var testCases = repository.Query<TestPlan>(query => query.Where(x => x.ID == id)).FindFirstOrDefault().TestCases;
            var results = new List<object>();

            foreach(var testCase in testCases)
            {
                results.Add(new { id = testCase.ID, cell = new List<object> { testCase.ID, testCase.Name, testCase.Tests.Count } });
            }
            
            var result = new
            {
                page = 1,
                total = 1,
                records = 1,
                rows = results
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(TestCase testcase)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(Request.QueryString["testPlanID"]);
                var testPlan = repository.Query<TestPlan>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();

                testPlan.Add(testcase);

                repository.Save(testPlan);

                return RedirectToAction("Index");  
            }

            return View(testcase);
        }
        
        public ActionResult Edit(int id)
        {
            var testcase = repository.Query<TestCase>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();

            return View(testcase);
        }

        [HttpPost]
        public ActionResult Edit(TestCase testcase)
        {
            if (ModelState.IsValid)
            {
                repository.Save(testcase);
                return RedirectToAction("Index");
            }

            return View(testcase);
        }

        public ActionResult Delete(int id)
        {

            var testcase = repository.Query<TestCase>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return View(testcase);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var testcase = repository.Query<TestCase>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            repository.Delete(testcase);
            return RedirectToAction("Index");
        }
    }
}