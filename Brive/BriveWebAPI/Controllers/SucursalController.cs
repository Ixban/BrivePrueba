using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BriveWebAPI.Controllers
{
    public class SucursalController : ApiController
    {
        [Route("api/sucursal/")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = BusineesLayer.Sucursal.getSucursales();
            return Ok(result);
        }

        [Route("api/sucursal/{id}")]
        [HttpGet]
        public ModelLayer.Result Get(int id)
        {
            var result = BusineesLayer.Sucursal.getSucursal(id);

            return result;
        }

        [Route("api/sucursal/")]
        [HttpPost]
        public IHttpActionResult Add(ModelLayer.Sucursal sucursal)
        {
            var result = BusineesLayer.Sucursal.AddSucursal(sucursal);
            return Ok(result);

        }

        [Route("api/sucursal/")]
        [HttpPut]
        public IHttpActionResult Put(ModelLayer.Sucursal sucursal)
        {
            var result = BusineesLayer.Sucursal.UpdateSucursal(sucursal);
            return Ok(result);

        }

        [Route("api/sucursal/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var result = BusineesLayer.Sucursal.deleteSucursal(id);
            return Ok(result);
        }
    }
}
