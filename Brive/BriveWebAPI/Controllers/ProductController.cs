using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BriveWebAPI.Controllers
{
    public class ProductController : ApiController
    {
        [Route("api/product/")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = BusineesLayer.Product.getProducts();
            return Ok(result);
        }

        [Route("api/product/{id}")]
        [HttpGet]
        public ModelLayer.Result Get(int id)
        {
            var result = BusineesLayer.Product.getProduct(id);

            return result;
        }

        [Route("api/product/")]
        [HttpPost]
        public IHttpActionResult Add(ModelLayer.Product product)
        {
            var result = BusineesLayer.Product.AddProduct(product);
            return Ok(result);

        }

        [Route("api/product/")]
        [HttpPut]
        public IHttpActionResult Put(ModelLayer.Product product)
        {
            var result = BusineesLayer.Product.updateProduct(product);
            return Ok(result);

        }

        [Route("api/product/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var result = BusineesLayer.Product.deleteProduct(id);
            return Ok(result);
        }
    }
}
