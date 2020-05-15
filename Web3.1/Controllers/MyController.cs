using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace Web2.Controllers
{
    public class MyController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }
        [HttpGet]
        public ActionResult GetStuff()
        {
            return View();
        }
        [HttpPost]
        public string GetStuff(string name1, string name2)
        {
            return name1 + name2;
        }
    }
}
