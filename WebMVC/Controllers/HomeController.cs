using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.BLL;
using Newtonsoft.Json;

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
        public ActionResult SummaryAssent()
        {
            var model = new SummaryAssent().Get();
            return View(model);
        }
        public ActionResult InvoicingReport()
        {
            var model = new InvoicingReport().Get();
            return View(model);
        }
        public ActionResult StockReport()
        {
            var model = new StockReport().Get();
            return View(model);
        }
        public string StockReportDetails(int id)
        {
            var model = new StockReport().Get().FirstOrDefault(s => s.Id == id);
            return JsonConvert.SerializeObject( model);
        }
    }
}