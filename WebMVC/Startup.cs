using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using WebMVC.Infrastructure;

[assembly: OwinStartupAttribute(typeof(WebMVC.Startup))]
namespace WebMVC
{
    using AppFunc = Func<IDictionary<string, object>, Task>;
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
           
        }
    }
}