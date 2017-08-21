using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using WebMVC.BLL;
using WebMVC.Infrastructure;
using WebMVC.Models;

[assembly: OwinStartupAttribute(typeof(WebMVC.Startup))]
namespace WebMVC
{
    using AppFunc = Func<IDictionary<string, object>, Task>;
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //   // ConfigureAuth(app);
            //    app.Run(context =>
            //    {
            //        context.Response.ContentType = "text/plain";
            //        return context.Response.WriteAsync("Hello world");
            //    });

            //1.使用app.Use方法将IdentityFactoryMiddleware和参数callback回掉函数注册到Owin Pipeline中
            //app.Use(typeof(IdentityFactoryMiddleware<T, IdentityFactoryOptions<T>>), args);
            //2.当IdentityFactoryMiddleware中间件被Invoke执行时，执行callback回掉函数，返回具体实例Instance
            //TResult instance = ((IdentityFactoryMiddleware<TResult, TOptions>) this).Options.Provider.Create(((IdentityFactoryMiddleware<TResult, TOptions>) this).Options, context);
            //3.将返回的实例存储在Owin Context中
            //context.Set<TResult>(instance);

            app.CreatePerOwinContext<AppIdentityDbContext>(AppIdentityDbContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
              app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/user/Login"),
            });
        }
    }
}