using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebApi.Controllers
{
    [RoutePrefix("HelpPage")]
    public class HomeController : Controller
    {
        [Route("FirstPage")]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
