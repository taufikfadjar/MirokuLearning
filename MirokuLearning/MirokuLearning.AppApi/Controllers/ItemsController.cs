using MirokuLearning.AppModel.APIViewModels;
using MirokuLearning.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MirokuLearning.AppApi.Controllers
{
    [RoutePrefix("api/items")]
    public class ItemsController : ApiController
    {
        private IItemServices ItemServices;
        public ItemsController(IItemServices itemServices)
        {
            ItemServices = itemServices;
        }

        // GET: api/Items
        [Route("")]
        public async Task<IEnumerable<object>> GetItems(string fields = null)
        {
            return await ItemServices.GetItems<ItemViewModel>(null, x=>x.ItemName, fields,1,100);
        }

        // GET: api/Items/5
        public async System.Threading.Tasks.Task<ItemViewModel> Get(string id)
        {
            return await ItemServices.GetItem<ItemViewModel>(x => x.ItemCode == id);
        }

        // POST: api/Items
        public async Task<IHttpActionResult> Post([FromBody]ItemViewModel item)
        {
            await ItemServices.CreateItem(item);

            return Ok();
            //return CreatedAtRoute("DefaultApi", new { id = article.ID }, article);
        }

        // PUT: api/Items/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Items/5
        public void Delete(int id)
        {

        }

        [Route("count")]
        [HttpGet]
        public async Task<IHttpActionResult> GetTotal()
        {
            var total = await ItemServices.GetTotal();
            return Ok(new { Total = total });
        }
    }
}
