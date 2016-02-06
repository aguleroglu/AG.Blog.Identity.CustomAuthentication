using Microsoft.AspNet.Identity;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Startup class'ınızın namespace'i uygulamanın temel nampespace'i aynı olmalıdır. 
//Bu sayade ilk olarak otomatik bir şekilde çalıştırılacaktır.
namespace AG.Blog.Identity.CustomAuthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Bu kısım authentication'ın nasıl yapılacağını belirtiyor. Farklı türleri de farklı yazılarda inceleyeceğiz.
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                //LoginPath, Unauthorize alındığı takdirde hangi sayfadan login olunması gerektiğini belirtiyor.
                LoginPath = new Microsoft.Owin.PathString("/Account/Login"),
                //AuthenticationType, birden fazla kullanılan authenticatation sistemlerinde kullanıcının hangi yapı üzerinden authenticate olduğunu belirtmek için kullanılır. 
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
        }
    }
}