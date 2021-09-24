using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Brive.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            List<ModelLayer.Inventory> inventoryList = new List<ModelLayer.Inventory>();
            inventoryList = returnInventory();
            return View(inventoryList);
        }

        public ActionResult Delete(int id)
        {
            List<ModelLayer.Inventory> inventoryList = new List<ModelLayer.Inventory>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44300/api/");

                //HTTP POST
                var postTask = client.DeleteAsync("inventory/" + id);
                postTask.Wait();
                logs("Delete Inventory", "Inventory");


                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    inventoryList = returnInventory();
                    return View("Index", inventoryList);
                }
            }

            inventoryList = returnInventory();
            return View("Index", inventoryList);

        }

        [HttpPost]
        public bool InventoryAdd(ModelLayer.Inventory inventory)
        {
            if (inventory.id == 0)
            {
                ModelLayer.Result result1 = new ModelLayer.Result();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44300/api/");

                    var postTask = client.PostAsJsonAsync<ModelLayer.Inventory>("inventory/", inventory);
                    postTask.Wait();
                    logs("Add Inventory", "Inventory");

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

                    var postTask = client.PutAsJsonAsync<ModelLayer.Inventory>("inventory/", inventory);
                    postTask.Wait();
                    logs("Update Inventory", "Inventory");

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
        public ActionResult GetInventory(int id)
        {
            ModelLayer.Result resultInventory = new ModelLayer.Result();
            resultInventory.Objects = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44300/api/");
                //HTTP GET
                var responseTask = client.GetAsync("inventory/" + id);
                responseTask.Wait();
                logs("Get Inventory", "Inventory");
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ModelLayer.Result>();
                    readTask.Wait();

                    ModelLayer.Inventory resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ModelLayer.Inventory>(readTask.Result.Object.ToString());

                    return Json(resultItemList);

                }

            }

            return Json(null);

        }

        public List<ModelLayer.Inventory> returnInventory()
        {
            ModelLayer.Result resultInventory = new ModelLayer.Result();
            List<ModelLayer.Inventory> inventoryList = new List<ModelLayer.Inventory>();
            resultInventory.Objects = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44300/api/");
                //HTTP GET
                var responseTask = client.GetAsync("inventory/");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ModelLayer.Result>();
                    readTask.Wait();
                    logs("Get Inventory", "Inventory");

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ModelLayer.Inventory resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ModelLayer.Inventory>(resultItem.ToString());
                        inventoryList.Add(resultItemList);

                    }

                }

            }
            return inventoryList;
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

        [HttpPost]
        public ActionResult GetProductos()
        {
            List<SelectListItem> productos = new List<SelectListItem>();

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
                    logs("Get Products", "Inventory");

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ModelLayer.Product resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ModelLayer.Product>(resultItem.ToString());
                        productos.Add(new SelectListItem { Text = resultItemList.name.ToString(), Value = resultItemList.id.ToString() });

                    }

                }

            }
            
            return Json(new SelectList(productos, "Value", "Text", JsonRequestBehavior.AllowGet));
        }


        [HttpPost]
        public ActionResult GetSucursales()
        {
            List<SelectListItem> sucursales = new List<SelectListItem>();

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
                    logs("Get Sucursals", "Inventory");

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ModelLayer.Sucursal resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ModelLayer.Sucursal>(resultItem.ToString());
                        sucursales.Add(new SelectListItem { Text = resultItemList.sucursalName.ToString(), Value = resultItemList.id.ToString() });

                    }

                }

            }

            return Json(new SelectList(sucursales, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
    }
}