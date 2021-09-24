using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace Brive.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            List<ModelLayer.Users> usuarioList = new List<ModelLayer.Users>();
            usuarioList = returnUsers();
            return View(usuarioList);
        }

        public ActionResult Delete(int id)
        {
            List<ModelLayer.Users> usuarioList = new List<ModelLayer.Users>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44300/api/");

                //HTTP POST
                var postTask = client.DeleteAsync("users/" + id);
                postTask.Wait();
                logs("Delete     User", "User");


                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    usuarioList = returnUsers();
                    return View("Index", usuarioList);
                }
            }

            usuarioList = returnUsers();
            return View("Index", usuarioList);

        }

        [HttpPost]
        public bool UsuarioAdd(ModelLayer.Users usuario)
        {
            List<ModelLayer.Users> usuarioList = new List<ModelLayer.Users>();
            if (usuario.id == 0)
            {
                ModelLayer.Result result1 = new ModelLayer.Result();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44300/api/");
                    
                    var postTask = client.PostAsJsonAsync<ModelLayer.Users>("users/", usuario);
                    postTask.Wait();
                    logs("Add User", "User");

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {   
                        return result1.Correct;
                    }
                }

                return result1.Correct;


            }
            else
            {
                ModelLayer.Result result1 = new ModelLayer.Result();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44300/api/");

                    var postTask = client.PutAsJsonAsync<ModelLayer.Users>("users/", usuario);
                    postTask.Wait();
                    logs("Update User", "User");

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return result1.Correct;
                    }
                }

                return result1.Correct;
            }
        }

        [HttpPost]
        public ActionResult GetUser(int id)
        {
            ModelLayer.Result resultProduct = new ModelLayer.Result();
            List<ModelLayer.Users> usuarioList = new List<ModelLayer.Users>();
            resultProduct.Objects = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44300/api/");
                //HTTP GET
                var responseTask = client.GetAsync("users/" + id);
                responseTask.Wait();
                logs("Get User", "User");
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ModelLayer.Result>();
                    readTask.Wait();

                    ModelLayer.Users resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ModelLayer.Users>(readTask.Result.Object.ToString());

                    return Json(resultItemList);

                }

            }

            return Json(null);

        }

        public List<ModelLayer.Users> returnUsers()
        {
            ModelLayer.Result resultProduct = new ModelLayer.Result();
            List<ModelLayer.Users> usuarioList = new List<ModelLayer.Users>();
            resultProduct.Objects = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44300/api/");
                //HTTP GET
                var responseTask = client.GetAsync("users/");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ModelLayer.Result>();
                    readTask.Wait();
                    logs("Get User", "User");

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ModelLayer.Users resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ModelLayer.Users>(resultItem.ToString());
                        usuarioList.Add(resultItemList);

                    }

                }

            }
            return usuarioList;
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
