using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Common;

namespace WebMVC
{
    public static class ButtonHelper
    {
        public static MvcHtmlString BootstrapButton(this HtmlHelper helper, string caption, ButtonStyle style, ButtonSize size)
        {
            if (size != ButtonSize.Normal)
            {
                return new MvcHtmlString(string.Format("<button type=\"button\" class=\"btn btn-{0} btn-{1}\">{2}</button>", style.ToString().ToLower(), ToBootstrapSize(size), caption));
            }
            return new MvcHtmlString(string.Format("<button type=\"button\" class=\"btn btn-{0}\">{1}</button>", style.ToString().ToLower(), caption));
        }
        public static MvcHtmlString BootstrapLink(this HtmlHelper helper, string Url, string caption, ButtonStyle style, ButtonSize size)
        {
            if (size != ButtonSize.Normal)
            {
                return new MvcHtmlString(string.Format("<link  class=\"btn btn-{0} btn-{1}\" href=\"{3}\">{2}</link>", style.ToString().ToLower(), ToBootstrapSize(size), caption,Url));
            }
            return new MvcHtmlString(string.Format("<link  class=\"btn btn-{0}\"  href=\"{2}\">{1}</link>", style.ToString().ToLower(), caption,Url));
        }
        private static string ToBootstrapSize(ButtonSize size)
        {
            string bootstrapSize = string.Empty;
            switch (size)
            {
                case ButtonSize.Large:
                    bootstrapSize = "lg";
                    break;

                case ButtonSize.Small:
                    bootstrapSize = "sm";
                    break;

                case ButtonSize.ExtraSmall:
                    bootstrapSize = "xs";
                    break;
            }
            return bootstrapSize;
        }

    }
}