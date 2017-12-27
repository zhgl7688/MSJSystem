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
using WebMVC.Models;

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
        List<AgentInput> agentInputList;
        List<BrandsInput> brandsInputList;

        List<Models.AgentInput> agentInputs
        {
            get { return agentInputList; }

        }

        List<Models.BrandsInput> brandsInputs
        {

            get
            {
                return brandsInputList;
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
        private void init()
        {
            var userName = User != null ? string.IsNullOrEmpty(User.Identity.Name) ? "" : User.Identity.Name : "";
            agentInputList = db.AgentInputs.Where(s => s.UserId == userName).ToList();
            brandsInputList = db.BrandsInputs.Where(s => s.UserId == userName).ToList();
            //代理数

            AgentStages.stages = db.BrandsInputs.Select(s => s.Stage).Distinct().OrderBy(s => s).ToList();
            AgentStages.stages.Insert(0, "起始阶段");
            AgentStages.agents = db.AgentInputs.Select(s => s.AgentName).Distinct().OrderBy(s => s).ToList();
            //品牌力设置
            var bs = db.BrandStrengthInit.FirstOrDefault(s => s.id == 1);
            if (bs != null)
            {
                AgentStages.BrandStrength_E = bs.BrandStrength_E;
                AgentStages.BrandStrength_M1 = bs.BrandStrength_M1;
            }
            //产品创新力部分设置
            AgentStages.ProductInnovationInit = db.ProductInnovationInit.First();
            var mpt = db.MarketPromotionInit.FirstOrDefault(s => s.id == 1);
            if (mpt != null)
            {
                AgentStages.M_AY1 = mpt.MarketPromotionInit_AY1;
                AgentStages.M_AY2 = mpt.MarketPromotionInit_AY2;
                AgentStages.M_AX1 = mpt.MarketPromotionInit_AX1;
                AgentStages.M_AX2 = mpt.MarketPromotionInit_AX2;
                AgentStages.M_AX3 = mpt.MarketPromotionInit_AX3;
                AgentStages.M_AX4 = mpt.MarketPromotionInit_AX4;
                AgentStages.M_AX5 = mpt.MarketPromotionInit_AX5;
                AgentStages.M_AX6 = mpt.MarketPromotionInit_AX6;
            }

            //渠道服务部分设置
            var cf = db.ChannelServiceInit.FirstOrDefault(s => s.id == 1);
            if (cf != null)
            {
                AgentStages.C_J1 = cf.ChannelService_J1;
                AgentStages.C_J2 = cf.ChannelService_J2;
            }
            //市场价格部分设置
            var mp = db.MarketPriceInit.FirstOrDefault(s => s.id == 1);
            if (mp != null)
            {
                AgentStages.MP_CD = mp.CD;
                AgentStages.MP_CE = mp.CE;
                AgentStages.MP_CF = mp.CF;
                AgentStages.MP_CM = mp.CM;
                AgentStages.MP_CN = mp.CN;
                AgentStages.MP_CO = mp.CO;
            }
            //市场容量设定

            AgentStages.CurrentShareInits = db.CurrentShareInit.ToList();

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
            init();
            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
            brandStrength = new BLL.BrandStrength(invertmentTable1);
            var model = brandStrength.Get();
            return View(model);
        }
        public ActionResult SummaryAssent()
        {
            init();
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
            init();
            if (agentInputs != null && agentInputs.Count > 0 && brandsInputs != null && brandsInputs.Count > 0)
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
            return Content("<script>alert('没有数据可用');location='" + Url.Action("index", "home") + "'</script>");

        }
        public ActionResult LastBrand()
        {
            init();
            if (agentInputs != null && agentInputs.Count > 0 && brandsInputs != null && brandsInputs.Count > 0)
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
            return Content("<script>alert('没有数据可用');location='" + Url.Action("index", "home") + "'</script>");


        }
        public ActionResult SecondPPT()
        {
            init();
            if (agentInputs != null && agentInputs.Count > 0 && brandsInputs != null && brandsInputs.Count > 0)
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
            return Content("<script>alert('没有数据可用');location='" + Url.Action("index", "home") + "'</script>");

        }
        public ActionResult ThirdPPT()
        {

            init();

            if (agentInputs != null && agentInputs.Count > 0 && brandsInputs != null && brandsInputs.Count > 0)
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
            return Content("<script>alert('没有数据可用');location='" + Url.Action("index", "home") + "'</script>");

        }
        //厂家主导的产品创新力
        public ActionResult ProductInnovation()
        {

            init();
            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
            brandStrength = new BLL.BrandStrength(invertmentTable1);
            productInnovation = new ProductInnovation(brandStrength, invertmentTable1);
            var model = productInnovation.Get();
            return View(model);
        }
        //渠道服务
        public ActionResult ChannelService()
        {
            init();
            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
            channelService = new ChannelService(invertmentTable1);
            var model = channelService.Get();
            return View(model);
        }
        //市场推广（包含促销投入）
        public ActionResult MarketPromotion()
        {

            init();
            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
            marketPromotion = new MarketPromotion(invertmentTable1);
            var model = marketPromotion.Get();
            return View(model);
        }
        //市场价格
        public ActionResult MarketPrice()
        {

            init();
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

            init();
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
            init();
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

            init();
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