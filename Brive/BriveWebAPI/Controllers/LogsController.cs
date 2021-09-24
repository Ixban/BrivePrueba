using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BriveWebAPI.Controllers
{
    public class LogsController : ApiController
    {

        [Route("api/logs/")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = BusineesLayer.logs.getLogs();
            return Ok(result);
        }

        [Route("api/logs/")]
        [HttpPost]
        public IHttpActionResult Add(ModelLayer.Log logs)
        {
            var result = BusineesLayer.logs.AddLogs(logs.users, logs.action, logs.module);
            return Ok(result);

        }

    }
}
