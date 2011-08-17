using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using QA_Test_Tracker.Configuration;
using QA_Test_Tracker.Models;
using Siege.Repository;

namespace QA_Test_Tracker.Controllers
{
    public class ActiveTestPlanController : GenericController<ActiveTestPlan>
    {
        public ActiveTestPlanController(IRepository<TestTrackerDatabase> repository) : base(repository)
        {
        }

        [HttpGet]
        public ActionResult New(int? buildID)
        {
            int id = Convert.ToInt32(Request.QueryString["buildID"]);
            var build = repository.Query<Build>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();

            return View("Create", build);
        }

        public override ActionResult Details(int id)
        {
            var activeTestPlan = repository.Query<ActiveTestPlan>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            return RedirectToAction("Details", "TestPlan", new {activeTestPlan.TestPlan.ID});
        }

        [HttpPost]
        public ActionResult Add(List<string> data)
        {
            int buildID = Convert.ToInt32(Request.QueryString["buildID"]);

            foreach(var stringID in data)
            {
                int id = Convert.ToInt32(stringID);

                var testPlan = repository.Query<TestPlan>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();

                var activeTestPlan = new ActiveTestPlan
                {
                    TestPlan = testPlan,
                    Build = repository.Query<Build>(query => query.Where(x => x.ID == buildID)).FindFirstOrDefault()
                };

                foreach(var testCase in testPlan.TestCases)
                {
                    var activeTestCase = new ActiveTestCase {TestCase = testCase};
                    
                    foreach(var test in testCase.Tests)
                    {
                        var activeTestStep = new ActiveTestStep {Test = test, Status = TestStatus.Pending};
                        activeTestCase.Add(activeTestStep);
                    }
                    
                    activeTestPlan.Add(activeTestCase);
                }
                
                repository.Save(activeTestPlan);
            }


            return Json(new { success = true });
        }

        public JsonResult List(int? buildID)
        {
            int id = Convert.ToInt32(Request.QueryString["buildID"]);
            if (id == 0) return Json(new { });

            var testPlans = repository.Query<ActiveTestPlan>(query => query.Where(x => x.Build.ID == id)).Find();

            var results = new List<object>();

            foreach (var testPlan in testPlans)
            {
                results.Add(new { id = testPlan.ID, cell = new List<object> { testPlan.ID, testPlan.TestPlan.Name, testPlan.TestCases.Count, testPlan.TestPlan.Feature.Name } });
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

        public ActionResult Remove(ActiveTestPlan testPlan)
        {
            return null;
        }
    }
}