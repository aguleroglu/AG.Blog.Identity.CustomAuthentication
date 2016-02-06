using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AG.Blog.Identity.CustomAuthentication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //Authoriza Attribute'u ile bu action'ın authentication gerektiren bir ation olduğunu belirtiyoruz.
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}