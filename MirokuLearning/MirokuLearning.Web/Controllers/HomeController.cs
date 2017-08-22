using MirokuLearning.AppModel.Views;
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

        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var test = await ItemServices.GetItems<ItemViewModel>(x=>x.ItemTotalQty == 0, x => x.ItemName, 1, 50);
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