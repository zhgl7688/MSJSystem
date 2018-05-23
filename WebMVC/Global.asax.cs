using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebMVC
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
          //  Application_AuthenticateRequest();

        }
        //protected void Application_AuthenticateRequest()
        //{
        //    var claims = new List<Claim>();
        //    claims.Add(new Claim(ClaimTypes.Name, "Jesse Liu"));
        //    claims.Add(new Claim(ClaimTypes.Role,"Users"));
        //    var identity = new ClaimsIdentity(claims, "MyclaimsLogin");
        //    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
        //    HttpContext.Current.User = principal;
        //}
        //保证同一次会话的SessionID不变
        protected void Session_Start(object sender, EventArgs e)
        { }

        protected void Session_End(object sender, EventArgs e)
        {
            Hashtable hOnline = (Hashtable)Application["Online"];
            if (hOnline != null)
            {
                if (hOnline[User.Identity.Name.ToLower()] != null)
                {
                    hOnline.Remove(User.Identity.Name.ToLower());
                    Application.Lock();
                    Application["Online"] = hOnline;
                    Application.UnLock();
                }
            }
        }

    }
}
