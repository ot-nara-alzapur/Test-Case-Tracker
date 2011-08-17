using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using QA_Test_Tracker.Configuration;
using QA_Test_Tracker.Models;
using Siege.Repository;

namespace QA_Test_Tracker.Controllers
{
    public class TestPlanController : GenericController<TestPlan>
    {
        public TestPlanController(IRepository<TestTrackerDatabase> repository) : base(repository)
        {
        }

        public JsonResult List(int? buildID)
        {
            int id = Convert.ToInt32(Request.QueryString["buildID"]);
            if (id == 0) return Json(new { });

            var addedPlans = repository.Query<ActiveTestPlan>(query => query.Where(x => x.Build.ID == id)).Find();
            var testPlans = repository.Query<TestPlan>().Find();
            var filteredPlans = testPlans.Where(x => !addedPlans.Any(y => y.TestPlan.ID == x.ID));

            var results = new List<object>();

            foreach (var testPlan in filteredPlans)
            {
                results.Add(new { id = testPlan.ID, cell = new List<object> { testPlan.ID, testPlan.Name, testPlan.TestCases.Count, testPlan.Feature.Name } });
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
    }
}