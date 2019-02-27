using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private PrimeContext primeContext;

        public HomeController(PrimeContext _primeContext)
        {
            primeContext = _primeContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string Index)
        {
            var t = new PrimeModel(primeContext);
            ViewBag.Response = "OK";
            var t1 = 0;
            if(int.TryParse(Index,out t1))
            {
                ViewBag.Response = string.Format("Prime at Index {0} is {1}", Index, t.GetPrimeNumber(t1));
            }
            else
            {
                ViewBag.Response = "Please provide valid index.";
            }
            return View();
        }

    }
}
