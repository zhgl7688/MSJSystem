using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Infrastructure
{
    public class LoginActionFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting (ActionExecutingContext filterContext)
        {
            Hashtable singleOnline = (Hashtable)filterContext.HttpContext.Application["Online"];
            if (singleOnline != null && singleOnline.ContainsKey(filterContext.HttpContext.Request["UserName"].ToLower()))
            {
                if (!singleOnline[filterContext.HttpContext.Request["UserName"].ToLower()].Equals(filterContext.HttpContext.Session.SessionID))
                {
                    filterContext.Result = new ContentResult
                    {
                        Content = "<script>if(confirm('你的账号已在别处登录，是否返回登录页面重新登录?')){window.location.href='/account/login';}else{window.close();}</script>"
                    }; 
                }
               
            }
            base.OnActionExecuting(filterContext);
        }
    }
}