using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BriveWebAPI.Controllers
{
    public class InventoryController : ApiController
    {
        [Route("api/inventory/")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = BusineesLayer.Inventory.getInventorys();
            return Ok(result);
        }

        [Route("api/inventory/{id}")]
        [HttpGet]
        public ModelLayer.Result Get(int id)
        {
            var result = BusineesLayer.Inventory.getInventory(id);

            return result;
        }

        [Route("api/inventory/")]
        [HttpPost]
        public IHttpActionResult Add(ModelLayer.Inventory inventory)
        {
            var result = BusineesLayer.Inventory.AddInventory(inventory);
            return Ok(result);

        }

        [Route("api/inventory/")]
        [HttpPut]
        public IHttpActionResult Put(ModelLayer.Inventory inventory)
        {
            var result = BusineesLayer.Inventory.updateInventory(inventory);
            return Ok(result);

        }

        [Route("api/inventory/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var result = BusineesLayer.Inventory.deleteInventory(id);
            return Ok(result);
        }
    }
}
