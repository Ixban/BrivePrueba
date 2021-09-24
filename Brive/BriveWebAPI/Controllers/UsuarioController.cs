using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BriveWebAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        [Route("api/users/")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = BusineesLayer.Users.getUsers();
            return Ok(result);
        }

        [Route("api/users/{id}")]
        [HttpGet]
        public ModelLayer.Result Get(int id)
        {
            var result = BusineesLayer.Users.GetUsuario(id);

            return result;
        }

        [Route("api/users/")]
        [HttpPost]
        public IHttpActionResult Add(ModelLayer.Users users)
        {
            var result = BusineesLayer.Users.AddUser(users);
            return Ok(result);

        }

        [Route("api/users/")]
        [HttpPut]
        public IHttpActionResult Put(ModelLayer.Users users)
        {
            var result = BusineesLayer.Users.UpdateUser(users);
            return Ok(result);

        }

        [Route("api/users/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var result = BusineesLayer.Users.UserDelete(id);
            return Ok(result);
        }

    }
}
