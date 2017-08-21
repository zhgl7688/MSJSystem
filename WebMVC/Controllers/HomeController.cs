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
        InvertmentTable1 invertmentTable1;
        BrandStrength brandStrength;
        PriceControl priceControl;
        ProductInnovation productInnovation;
        CurrentShare currentShare;
        StockReport stockReport;
        Investment investment;
        MarketPrice marketPrice;
        IntentionIndex intentionIndex;
        MarketPromotion marketPromotion;
        ChannelService channelService;
        MarketPriceTemp marketPriceTemp;
         LastBrand lastBrand;
        SummaryAssent summaryAssent;
        InvoicingReport invoicingReport;
        FirstPPT firstPPT;
        SecondPPT secondPPT;
        ThirdPPT thirdPPT;
        public HomeController()
        {
            invertmentTable1 = new InvertmentTable1();
   
            brandStrength = new BLL.BrandStrength(invertmentTable1);
            channelService = new ChannelService(invertmentTable1);
            marketPromotion = new MarketPromotion(invertmentTable1);
            productInnovation = new ProductInnovation(brandStrength, invertmentTable1);
            priceControl = new PriceControl(invertmentTable1);
            marketPriceTemp = new MarketPriceTemp(priceControl);
            intentionIndex = new BLL.IntentionIndex(brandStrength, productInnovation, marketPromotion, channelService, marketPriceTemp);
            currentShare = new BLL.CurrentShare(intentionIndex, priceControl);
            marketPrice = new MarketPrice(priceControl, productInnovation, currentShare);

            stockReport = new StockReport(invertmentTable1, marketPrice);
            investment = new Investment(invertmentTable1, stockReport);
            invoicingReport = new BLL.InvoicingReport(currentShare, marketPrice, stockReport);
            summaryAssent = new BLL.SummaryAssent(stockReport, invoicingReport, marketPrice, investment, currentShare);
            lastBrand = new LastBrand(currentShare);
            firstPPT = new BLL.FirstPPT(marketPrice, investment,invertmentTable1, summaryAssent, lastBrand, invoicingReport,priceControl);
            secondPPT = new BLL.SecondPPT(marketPrice, investment, invertmentTable1, summaryAssent, lastBrand, invoicingReport, priceControl, currentShare, firstPPT);
            thirdPPT = new BLL.ThirdPPT(marketPrice, investment, invertmentTable1, summaryAssent, lastBrand, invoicingReport, priceControl, currentShare, secondPPT);

        }
        
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
            var model = invertmentTable1.getBrandTable().OrderByDescending(s => s.Stage).ThenByDescending(s => s.Brand);
            return View(model);
        }
        public ActionResult InvertmentTable()
        {
            var model = investment.Get().OrderByDescending(s => s.Stage);
            return View(model);
        }
        public ActionResult BrandStrength()
        {
            var model = brandStrength.Get();
            return View(model);
        }
        public ActionResult SummaryAssent()
        {
            var model =  summaryAssent.Get();
            return View(model);
        }
        public ActionResult InvoicingReport()
        {
            var model =invoicingReport.Get();
            return View(model);
        }
        public ActionResult StockReport()
        {
            var model =stockReport.Get();
            return View(model);
        }
        public string StockReportDetails(int id)
        {
            var model = stockReport.Get().FirstOrDefault(s => s.Id == id);
            return JsonConvert.SerializeObject(model);
        }
        /// <summary>
        /// 市场容量及各品牌当年占有率
        /// </summary>  
        public ActionResult CurrentShare()
        {
            var model = currentShare.Get();
            return View(model);
        }
        /// <summary>
        /// 各品牌购买意愿指数
        /// </summary>
        public ActionResult IntentionIndex()
        {
            var model = intentionIndex.Get();
            return View(model);
        }
        public ActionResult FirstPPT()
        {
            var model = firstPPT.GetFirstPPTList();
            return View(model);
        }
        public ActionResult LastBrand()
        {
            var model = lastBrand.Get();
            return View(model);
        }
        public ActionResult SecondPPT()
        {
            var model = secondPPT.GetFirstPPTList();
            return View(model);
        }
        public ActionResult ThirdPPT()
        {
            var model = thirdPPT.GetPPTList();
            return View(model);
        }

        public ActionResult ProductInnovation()
        {
            var model = productInnovation.Get();
            return View(model);
        }
        public ActionResult MarketPrice()
        {
            var model = marketPrice.Get();
            return View(model);
        }
    }
}