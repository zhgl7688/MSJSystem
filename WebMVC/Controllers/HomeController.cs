using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using WebMVC.BLL;
using WebMVC.Infrastructure;

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

        List<Models.AgentInput> agentInputs
        {
            get { return db.AgentInputs.Where(s => s.UserId == User.Identity.Name).ToList(); }

        }

        List<Models.BrandsInput> brandsInputs
        {

            get
            {
                var userName = string.IsNullOrEmpty(User.Identity.Name) ? "" : "admin";
                return db.BrandsInputs.Where(s => s.UserId == userName).ToList();
            }
        }


        AppIdentityDbContext db = new AppIdentityDbContext();
        string useId = "";// Common.AgentName.代1.ToString();
        bool debug = false;
        public HomeController()
        {
            //if (!debug)
            //    useId = User.Identity.Name;
            //agentInputs = db.AgentInputs.Where(s =>  s.UserId == useId).ToList();
            //brandsInputs = db.BrandsInputs.ToList();

            //invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
            //  brandStrength = new BLL.BrandStrength(invertmentTable1);
            //  channelService = new ChannelService(invertmentTable1);
            //  marketPromotion = new MarketPromotion(invertmentTable1);
            //  productInnovation = new ProductInnovation(brandStrength, invertmentTable1);
            //  priceControl = new PriceControl(invertmentTable1);
            //  marketPriceTemp = new MarketPriceTemp(priceControl);
            //  intentionIndex = new BLL.IntentionIndex(brandStrength, productInnovation, marketPromotion, channelService, marketPriceTemp);
            //  currentShare = new BLL.CurrentShare(intentionIndex, priceControl);
            //  marketPrice = new MarketPrice(priceControl, productInnovation, currentShare);

            //  stockReport = new StockReport(invertmentTable1, marketPrice);
            //  investment = new Investment(invertmentTable1, stockReport);
            //  invoicingReport = new BLL.InvoicingReport(currentShare, marketPrice, stockReport);
            //  summaryAssent = new BLL.SummaryAssent(stockReport, invoicingReport, marketPrice, investment, currentShare);
            //  lastBrand = new LastBrand(currentShare,invertmentTable1.GetAgentCount);
            //  firstPPT = new BLL.FirstPPT(marketPrice, investment,invertmentTable1, summaryAssent, lastBrand, invoicingReport,priceControl);
            //  secondPPT = new BLL.SecondPPT(marketPrice, investment, invertmentTable1, summaryAssent, lastBrand, invoicingReport, priceControl, currentShare, firstPPT);
            //  thirdPPT = new BLL.ThirdPPT(marketPrice, investment, invertmentTable1, summaryAssent, lastBrand, invoicingReport, priceControl, currentShare, secondPPT);

        }

        public ActionResult Index()
        {
            //  ViewData["role"] = HttpContext.User.IsInRole("品牌商");
            return View();
        }

        public ActionResult BaseInfo()
        {
            return View();
        }


        public ActionResult InvertmentTable1()
        {
          
            var model = invertmentTable1.getBrandTable().OrderByDescending(s => s.Stage).ThenByDescending(s => s.Brand);
            return View(model);
        }

        public ActionResult BrandStrength()
        {
            
            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
            brandStrength = new BLL.BrandStrength(invertmentTable1);
            var model = brandStrength.Get();
            return View(model);
        }
        public ActionResult SummaryAssent()
        {
           
            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
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

            var model = summaryAssent.Get();
            return View(model);
        }

        //进货报表
        public ActionResult StockReport()
        {
      
            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
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

            var model = stockReport.Get();
            return View(model);
        }
        public string StockReportDetails(int id)
        {
            var model = stockReport.Get().FirstOrDefault(s => s.Id == id);
            return JsonConvert.SerializeObject(model);
        }




        public ActionResult FirstPPT()
        {
 
            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
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
            lastBrand = new LastBrand(currentShare, invertmentTable1.GetAgentCount);
            firstPPT = new BLL.FirstPPT(marketPrice, investment, invertmentTable1, summaryAssent, lastBrand, invoicingReport, priceControl);


            var model = firstPPT.GetFirstPPTList();
            return View(model);
        }
        public ActionResult LastBrand()
        { 

            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
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
            lastBrand = new LastBrand(currentShare, invertmentTable1.GetAgentCount);
            var model = lastBrand.Get();
            return View(model);
        }
        public ActionResult SecondPPT()
        {
           

            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
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
            lastBrand = new LastBrand(currentShare, invertmentTable1.GetAgentCount);
            firstPPT = new BLL.FirstPPT(marketPrice, investment, invertmentTable1, summaryAssent, lastBrand, invoicingReport, priceControl);
            secondPPT = new BLL.SecondPPT(marketPrice, investment, invertmentTable1, summaryAssent, lastBrand, invoicingReport, priceControl, currentShare, firstPPT);

            var model = secondPPT.GetFirstPPTList();
            return View(model);
        }
        public ActionResult ThirdPPT()
        {
           

            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
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
            lastBrand = new LastBrand(currentShare, invertmentTable1.GetAgentCount);
            firstPPT = new BLL.FirstPPT(marketPrice, investment, invertmentTable1, summaryAssent, lastBrand, invoicingReport, priceControl);
            secondPPT = new BLL.SecondPPT(marketPrice, investment, invertmentTable1, summaryAssent, lastBrand, invoicingReport, priceControl, currentShare, firstPPT);
            thirdPPT = new BLL.ThirdPPT(marketPrice, investment, invertmentTable1, summaryAssent, lastBrand, invoicingReport, priceControl, currentShare, secondPPT);


            var model = thirdPPT.GetPPTList();
            return View(model);
        }
        //厂家主导的产品创新力
        public ActionResult ProductInnovation()
        {
           

            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
            brandStrength = new BLL.BrandStrength(invertmentTable1);
            productInnovation = new ProductInnovation(brandStrength, invertmentTable1);
            var model = productInnovation.Get();
            return View(model);
        }
        //渠道服务
        public ActionResult ChannelService()
        {
           invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
            channelService = new ChannelService(invertmentTable1);
            var model = channelService.Get();
            return View(model);
        }
        //市场推广（包含促销投入）
        public ActionResult MarketPromotion()
        {
            

            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
            marketPromotion = new MarketPromotion(invertmentTable1);
            var model = marketPromotion.Get();
            return View(model);
        }
        //市场价格
        public ActionResult MarketPrice()
        {
          

            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
            brandStrength = new BLL.BrandStrength(invertmentTable1);
            channelService = new ChannelService(invertmentTable1);
            marketPromotion = new MarketPromotion(invertmentTable1);
            productInnovation = new ProductInnovation(brandStrength, invertmentTable1);
            priceControl = new PriceControl(invertmentTable1);
            marketPriceTemp = new MarketPriceTemp(priceControl);
            intentionIndex = new BLL.IntentionIndex(brandStrength, productInnovation, marketPromotion, channelService, marketPriceTemp);
            currentShare = new BLL.CurrentShare(intentionIndex, priceControl);
            marketPrice = new MarketPrice(priceControl, productInnovation, currentShare);

            var model = marketPrice.Get();
            return View(model);
        }
        // 各品牌购买意愿指数
        public ActionResult IntentionIndex()
        {
             

            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
            brandStrength = new BLL.BrandStrength(invertmentTable1);
            channelService = new ChannelService(invertmentTable1);
            marketPromotion = new MarketPromotion(invertmentTable1);
            productInnovation = new ProductInnovation(brandStrength, invertmentTable1);
            priceControl = new PriceControl(invertmentTable1);
            marketPriceTemp = new MarketPriceTemp(priceControl);
            intentionIndex = new BLL.IntentionIndex(brandStrength, productInnovation, marketPromotion, channelService, marketPriceTemp);

            var model = intentionIndex.Get();
            return View(model);
        }
        //价格管控表
        public ActionResult PriceControl()
        {
           

            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
            priceControl = new PriceControl(invertmentTable1);

            var model = priceControl.Get();
            return View(model);
        }
        // 市场容量及各品牌当年占有率
        public ActionResult CurrentShare()
        {
           
            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
            brandStrength = new BLL.BrandStrength(invertmentTable1);
            channelService = new ChannelService(invertmentTable1);
            marketPromotion = new MarketPromotion(invertmentTable1);
            productInnovation = new ProductInnovation(brandStrength, invertmentTable1);
            priceControl = new PriceControl(invertmentTable1);
            marketPriceTemp = new MarketPriceTemp(priceControl);
            intentionIndex = new BLL.IntentionIndex(brandStrength, productInnovation, marketPromotion, channelService, marketPriceTemp);
            currentShare = new BLL.CurrentShare(intentionIndex, priceControl);

            var model = currentShare.Get();
            return View(model);
        }
        //进销存报表
        public ActionResult InvoicingReport()
        {
           

            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
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

            var model = invoicingReport.Get();
            return View(model);
        }

        //投资表
        public ActionResult InvertmentTable()
        {
           

            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);

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


            var model = investment.Get().OrderByDescending(s => s.Stage);
            return View(model);
        }
    }
}