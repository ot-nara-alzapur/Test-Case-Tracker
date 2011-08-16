using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using QA_Test_Tracker.Configuration;
using QA_Test_Tracker.Models;
using Siege.Repository;

namespace QA_Test_Tracker.Controllers
{
    public class TestStepController : GenericController<TestStep>
    {
        public TestStepController(IRepository<TestTrackerDatabase> repository) : base(repository)
        {
        }

        public JsonResult List(int? testCaseID)
        {
            int id = Convert.ToInt32(Request.QueryString["testCaseID"]);
            if (id == 0) return Json(new { });
            var testSteps = repository.Query<TestCase>(query => query.Where(x => x.ID == id)).FindFirstOrDefault().Tests;
            var results = new List<object>();

            foreach (var testStep in testSteps)
            {
                results.Add(new { id = testStep.ID, cell = new List<object> { testStep.ID, testStep.Name } });
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
        public override ActionResult Create(TestStep testStep)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(Request.QueryString["testCaseID"]);
                var testCase = repository.Query<TestCase>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();

                testCase.Add(testStep);

                repository.Save(testCase);

                return RedirectToAction("Index");
            }

            return View(testStep);
        }
    }
}