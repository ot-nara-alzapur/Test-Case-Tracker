using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using QA_Test_Tracker.Configuration;
using QA_Test_Tracker.Models;
using Siege.Repository;

namespace QA_Test_Tracker.Controllers
{   
    public class TestCaseController : GenericController<TestCase>
    {
        public TestCaseController(IRepository<TestTrackerDatabase> repository) : base(repository)
        {
        }

        public JsonResult List(int? testPlanID)
        {
            int id = Convert.ToInt32(Request.QueryString["testPlanID"]);
            if (id == 0) return Json(new {});
            var testCases =
                repository.Query<TestPlan>(query => query.Where(x => x.ID == id)).FindFirstOrDefault().TestCases;
            var results = new List<object>();

            foreach (var testCase in testCases)
            {
                results.Add(new {id = testCase.ID, cell = new List<object> {testCase.ID, testCase.Name, testCase.Tests.Count}});
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
        public override ActionResult Create(TestCase testCase)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(Request.QueryString["testPlanID"]);
                var testPlan = repository.Query<TestPlan>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();

                testPlan.Add(testCase);

                repository.Save(testPlan);

                return RedirectToAction("Index");
            }

            return View(testCase);
        }

        [HttpPost]
        public ActionResult EditTestComponent(TestComponent component)
        {
            return RedirectToAction("Edit", "TestComponent", new {id = component.ID});
        }
    }
}