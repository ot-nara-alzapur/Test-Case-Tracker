﻿using System.Web.Mvc;

namespace QA_Test_Tracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }
    }
}