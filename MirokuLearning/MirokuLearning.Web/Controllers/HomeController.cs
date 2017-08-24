using MirokuLearning.AppModel.Views;
using MirokuLearning.Business.Core;
using MirokuLearning.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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

        public async System.Threading.Tasks.Task<ActionResult> Index(string SearchString, int page = 1, int pageSize = 25)
        {

            page = page > 0 ? page : 1;
            pageSize = pageSize > 0 ? pageSize : 25;
            Expression<Func<Item, bool>> criteria = null;

            if (!string.IsNullOrEmpty(SearchString))
            {
                criteria = x => x.ItemCode.Contains(SearchString) || x.ItemDescription.Contains(SearchString) || x.ItemName.Contains(SearchString); 
            }

            var totalCount = await ItemServices.GetTotal(criteria);
            var itemViewModels = await ItemServices.GetItems<ItemViewModel>(criteria, x => x.ItemName, page, pageSize);

            IPagedList<ItemViewModel> pageOrders = new StaticPagedList<ItemViewModel>(itemViewModels, page, pageSize, totalCount);

            ViewBag.CurrentFilter = SearchString;

            return View(pageOrders);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> CreateItem(ItemViewModel item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await ItemServices.CreateItem(item);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again");
            }

            return View(item);
        }


        public ActionResult CreateItem()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> EditItem(int id)
        {
            var itemViewModels = await ItemServices.GetItem<ItemViewModel>(x => x.ItemId == id);
            return View(itemViewModels);
        }


    }
}