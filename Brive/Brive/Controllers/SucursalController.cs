using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Brive.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index()
        {
            List<ModelLayer.Sucursal> sucursalList = new List<ModelLayer.Sucursal>();
            sucursalList = returnSucursal();
            return View(sucursalList);
        }

        public ActionResult Delete(int id)
        {
            List<ModelLayer.Sucursal> sucursalList = new List<ModelLayer.Sucursal>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44300/api/");

                //HTTP POST
                var postTask = client.DeleteAsync("sucursal/" + id);
                postTask.Wait();
                logs("Delete Sucursal", "Sucursal");


                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    sucursalList = returnSucursal();
                    return View("Index", sucursalList);
                }
            }

            sucursalList = returnSucursal();
            return View("Index", sucursalList);

        }

        [HttpPost]
        public bool SucursalAdd(ModelLayer.Sucursal Sucursal)
        {
            if (Sucursal.id == 0)
            {
                ModelLayer.Result result1 = new ModelLayer.Result();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44300/api/");

                    var postTask = client.PostAsJsonAsync<ModelLayer.Sucursal>("sucursal/", Sucursal);
                    postTask.Wait();
                    logs("Add Sucursal", "Sucursal");

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

                    var postTask = client.PutAsJsonAsync<ModelLayer.Sucursal>("sucursal/", Sucursal);
                    postTask.Wait();
                    logs("Update Sucursal", "Sucursal");

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
        public ActionResult GetSucursal(int id)
        {
            ModelLayer.Result resultProduct = new ModelLayer.Result();
            resultProduct.Objects = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44300/api/");
                //HTTP GET
                var responseTask = client.GetAsync("sucursal/" + id);
                responseTask.Wait();
                logs("Get Sucursal", "Sucursal");
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ModelLayer.Result>();
                    readTask.Wait();

                    ModelLayer.Sucursal resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ModelLayer.Sucursal>(readTask.Result.Object.ToString());

                    return Json(resultItemList);

                }

            }

            return Json(null);

        }

        public List<ModelLayer.Sucursal> returnSucursal()
        {
            ModelLayer.Result resultProduct = new ModelLayer.Result();
            List<ModelLayer.Sucursal> sucursalList = new List<ModelLayer.Sucursal>();
            resultProduct.Objects = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44300/api/");
                //HTTP GET
                var responseTask = client.GetAsync("sucursal/");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ModelLayer.Result>();
                    readTask.Wait();
                    logs("Get Sucursal", "Sucursal");

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ModelLayer.Sucursal resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ModelLayer.Sucursal>(resultItem.ToString());
                        sucursalList.Add(resultItemList);

                    }

                }

            }
            return sucursalList;
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
