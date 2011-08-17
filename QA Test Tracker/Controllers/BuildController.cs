using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using QA_Test_Tracker.Configuration;
using QA_Test_Tracker.Models;
using Siege.Repository;

namespace QA_Test_Tracker.Controllers
{
    public class BuildController : GenericController<Build>
    {
        public BuildController(IRepository<TestTrackerDatabase> repository) : base(repository)
        {
        }

        public JsonResult List(int? relaseID)
        {
            int id = Convert.ToInt32(Request.QueryString["releaseID"]);
            if (id == 0) return Json(new { }, JsonRequestBehavior.AllowGet);
            var builds = repository.Query<Release>(query => query.Where(x => x.ID == id)).FindFirstOrDefault().Builds;
            var results = new List<object>();
            if (builds == null) return Json(new { }, JsonRequestBehavior.AllowGet);
            foreach (var build in builds)
            {
                var x = new
                        {
                            ID = build.ID,
                            Product = build.Product.Name,
                            TestPlan = build.TestPlans.Count,
                            ReleaseDate = build.Release.ReleaseDate,
                            BuildNumber = build.BuildNumber
                        };
                results.Add(new { id = build.ID, cell = new List<object> { build.ID, build.Product.Name, build.TestPlans.Count, build.Release.ReleaseDate.ToShortDateString(), build.BuildNumber } });
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
        public override ActionResult Create(Build build)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(Request.QueryString["releaseID"]);
                var release = repository.Query<Release>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
                build.Status = BuildStatus.InProgress;
                release.Add(build);

                repository.Save(release);

                return RedirectToAction("Index");
            }

            return View(build);
        }

        public ActionResult Clone(int id)
        {
            var build = repository.Query<Build>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();
            var newBuild = new Build {Product = build.Product, Release = build.Release};

            foreach(var testPlan in build.TestPlans)
            {
                var newTestPlan = new ActiveTestPlan {Build = build};

                foreach(var testCase in testPlan.TestCases)
                {
                    var newTestCase = new ActiveTestCase {ActiveTestPlan = newTestPlan, TestCase = testCase.TestCase};

                    foreach(var test in testCase.Tests)
                    {
                        var newTest = new ActiveTestStep
                        {
                            ActiveTestCase = newTestCase,
                            Status = TestStatus.Pending,
                            Test = test.Test
                        };

                        if(test.Status == TestStatus.Pending)
                        {
                            test.Status = TestStatus.Untested;
                        }

                        newTestCase.Add(newTest);
                    }

                    newTestPlan.TestCases.Add(newTestCase);
                }

                newBuild.TestPlans.Add(newTestPlan);
            }

            build.Status = BuildStatus.Closed;
            
            repository.Transact(r =>
            {
                r.Save(newBuild);
                r.Save(build);
            });
            

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            int buildID = Convert.ToInt32(Request.QueryString["buildID"]);
            var build = repository.Query<Build>(query => query.Where(x => x.ID == buildID)).FindFirstOrDefault();

            var activeTestPlan = repository.Query<ActiveTestPlan>(query => query.Where(x => x.ID == id)).FindFirstOrDefault();

            build.TestPlans.Remove(activeTestPlan);
            
            repository.Delete(activeTestPlan);
            repository.Save(build);


            return RedirectToAction("Details", new {id = buildID});
        }
    }
}