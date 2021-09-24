using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Brive.Controllers
{
    public class ProductoController : Controller
    {
        public ActionResult Index()
        {
            List<ModelLayer.Product> productList = new List<ModelLayer.Product>();
            productList = returnProducts();
            return View(productList);
        }

        public ActionResult Delete(int id)
        {
            List<ModelLayer.Product> productList = new List<ModelLayer.Product>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44300/api/");

                //HTTP POST
                var postTask = client.DeleteAsync("product/" + id);
                postTask.Wait();
                logs("Delete Product", "Product");


                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    productList = returnProducts();
                    return View("Index", productList);
                }
            }

            productList = returnProducts();
            return View("Index", productList);

        }

        [HttpPost]
        public bool ProductoAdd(ModelLayer.Product product)
        {
            if (product.id == 0)
            {
                ModelLayer.Result result1 = new ModelLayer.Result();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44300/api/");

                    var postTask = client.PostAsJsonAsync<ModelLayer.Product>("product/", product);
                    postTask.Wait();
                    logs("Add Product", "Product");

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        result1.Correct = true;
                        return result1.Correct;
                    }
                }

                result1.Correct = false;
                return result1.Correct;


            }
            else
            {
                ModelLayer.Result result1 = new ModelLayer.Result();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44300/api/");

                    var postTask = client.PutAsJsonAsync<ModelLayer.Product>("product/", product);
                    postTask.Wait();
                    logs("Update Product", "Product");

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        result1.Correct = true;
                        return result1.Correct;
                    }
                }

                result1.Correct = true;
                return result1.Correct;
            }
        }

        [HttpPost]
        public ActionResult GetProducto(int id)
        {
            ModelLayer.Result resultProduct = new ModelLayer.Result();
            resultProduct.Objects = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44300/api/");
                //HTTP GET
                var responseTask = client.GetAsync("product/" + id);
                responseTask.Wait();
                logs("Get Product", "Product");
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ModelLayer.Result>();
                    readTask.Wait();

                    ModelLayer.Product resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ModelLayer.Product>(readTask.Result.Object.ToString());

                    return Json(resultItemList);

                }

            }

            return Json(null);

        }

        public List<ModelLayer.Product> returnProducts()
        {
            ModelLayer.Result resultProduct = new ModelLayer.Result();
            List<ModelLayer.Product> productList = new List<ModelLayer.Product>();
            resultProduct.Objects = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44300/api/");
                //HTTP GET
                var responseTask = client.GetAsync("product/");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ModelLayer.Result>();
                    readTask.Wait();
                    logs("Get Product", "Product");

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ModelLayer.Product resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ModelLayer.Product>(resultItem.ToString());
                        productList.Add(resultItemList);

                    }

                }

            }
            return productList;
        }

        public void logs(string action, string module)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44300/api/");
                ModelLayer.Log log = new ModelLayer.Log();
                log.users = (ModelLayer.Users)Session["LogIn"];
                log.action = action;
                log.module = module;
                var postTask = client.PostAsJsonAsync<ModelLayer.Log>("logs/", log);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine(result.IsSuccessStatusCode);
                }
            }
        }
    }
}
