using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.BLL;

namespace WebMVC.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
        public ActionResult InvertmentTable1()
        {
            var model = new InvertmentTable1().getBrandsInputs().OrderByDescending(s=>s.Stage).ThenByDescending(s=>s.Brand);
            return View(model);
        }
        public ActionResult InvertmentTable()
        {
            var model = new Investment().Get().OrderByDescending(s => s.Stage);
            return View(model);
        }
        public ActionResult BrandStrength()
        {
            var model = new BrandStrength().Get();
            return View(model);
        }
    }
}