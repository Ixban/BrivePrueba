using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Brive.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn(string username, string password)
        {
            var result = BusineesLayer.Users.LogIn(username);

            ModelLayer.Users Usuario = new ModelLayer.Users();

            if (result.Object != null)
            {

                Usuario.id = int.Parse(((ModelLayer.Users)result.Object).id.ToString());
                Usuario.email = ((ModelLayer.Users)result.Object).email.ToString();
                Usuario.password = ((ModelLayer.Users)result.Object).password.ToString();


                if (Usuario.email == username && Usuario.password == password)
                {
                    Session["LogIn"] = Usuario;
                    TempData["LogInMessage"] = "Sesión Iniciada";
                    return RedirectToAction("../Main/Index");
                }
                else
                {
                    return RedirectToAction("../Home/Index");
                }


            }
            else
            {
                return RedirectToAction("../Home/Index");
            }
        }

        public ActionResult LogOut()
        {
            Session.Remove("LogIn");

            return RedirectToAction("../Home/Index");
        }

    }
}