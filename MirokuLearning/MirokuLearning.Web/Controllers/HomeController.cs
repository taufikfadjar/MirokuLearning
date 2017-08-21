using MirokuLearning.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MirokuLearning.Web.Controllers
{
    public class HomeController : Controller
    {
        private IItemServices ItemServices;
        public HomeController(IItemServices itemServices)
        {
            ItemServices = itemServices;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}