using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Brive.Controllers
{
    public class LogsController : Controller
    {
        // GET: Logs
        public ActionResult Index()
        {
            List<ModelLayer.Log> logsList = new List<ModelLayer.Log>();
            logsList = returnLogs();
            return View(logsList);
        }

        public List<ModelLayer.Log> returnLogs()
        {
            ModelLayer.Result resultProduct = new ModelLayer.Result();
            List<ModelLayer.Log> logList = new List<ModelLayer.Log>();
            resultProduct.Objects = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44300/api/");
                //HTTP GET
                var responseTask = client.GetAsync("logs/");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ModelLayer.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ModelLayer.Log resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ModelLayer.Log>(resultItem.ToString());
                        logList.Add(resultItemList);

                    }

                }

            }
            return logList;
        }

    }
}
