using AG.Blog.Identity.CustomAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//HttpContext.GetOwinContext() kısmı bu namespace üzerinde tanımlı olduğu için sayfaya eklememiz gerekmektedir.
using Microsoft.Owin.Host.SystemWeb;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace AG.Blog.Identity.CustomAuthentication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM vm)
        {
            if (ModelState.IsValid)
            {
                
                var authentication = HttpContext.GetOwinContext().Authentication;

                //Yeni bir Claims yaratıyoruz ve bu Claims'i ApplicationCookie ile(Startup ta belirttiğimiz ile aynı) oluşturuyoruz.
                var identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
                //Email bilgisini yeni bir Claim olarak ekliyoruz
                //Bu kısımda projenize özel olarak oluşturduğunuz claims'leri de ekleyebilirsiniz.
                //Key-Value olarak çalışırlar.
                identity.AddClaim(new Claim(ClaimTypes.Email,vm.Email));
                //Name bilgisiniz görüntülenebilmesi ClaimsTypes.Name olarakta ekliyoruz.
                identity.AddClaim(new Claim(ClaimTypes.Name,vm.Email));

                //Daha sonra oluşturduğumuz identity ile signin oluyoruz.
                authentication.SignIn(identity);

                if (String.IsNullOrEmpty(vm.ReturnUrl))
                {
                    return Redirect("/");
                }
                else
                {
                    return Redirect(vm.ReturnUrl);
                }

            }

            return View(vm);

        }

        public ActionResult Logout()
        {
            var authentication = HttpContext.GetOwinContext().Authentication;
            authentication.SignOut();

            return Redirect("/");
        }
    }
}