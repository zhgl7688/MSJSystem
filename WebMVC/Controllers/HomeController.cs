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
           
            agentInputList = db.AgentInputs.ToList();
            brandsInputList = db.BrandsInputs.OrderBy(s=>s.Stage).ToList();
            //代理数

            AgentStages.stages = db.BrandsInputs.Select(s => s.Stage).Distinct().OrderBy(s => s).ToList();
            AgentStages.stages.Insert(0, "起始阶段");
            AgentStages.agents = db.AgentInputs.Select(s => s.AgentName).Distinct().OrderBy(s => s).ToList();
            var datainit = db.DataInits.First();
            //品牌力设置

            AgentStages.BrandStrength_E = datainit.BrandStrength_E;
            AgentStages.BrandStrength_M1 = datainit.BrandStrength_M1;

            AgentStages.ProductInnovationInit = new ProductInnovationInit
            {
                ProductInnovation_AC = datainit.ProductInnovation_AC,
                ProductInnovation_AL = datainit.ProductInnovation_AL,
                ProductInnovation_CB1 = datainit.ProductInnovation_CB1,
                ProductInnovation_CB2 = datainit.ProductInnovation_CB2,
                ProductInnovation_CB3 = datainit.ProductInnovation_CB3,
                ProductInnovation_CB4 = datainit.ProductInnovation_CB4,
                ProductInnovation_CB5 = datainit.ProductInnovation_CB5,
                ProductInnovation_CK1 = datainit.ProductInnovation_CK1,
                ProductInnovation_CK2 = datainit.ProductInnovation_CK2,
                ProductInnovation_CK3 = datainit.ProductInnovation_CK3,
                ProductInnovation_CK4 = datainit.ProductInnovation_CK4,
                ProductInnovation_CK5 = datainit.ProductInnovation_CK5,
                ProductInnovation_J = datainit.ProductInnovation_J,
                ProductInnovation_M = datainit.ProductInnovation_M,
                ProductInnovation_S = datainit.ProductInnovation_S,
                ProductInnovation_T = datainit.ProductInnovation_T
            };
            //产品创新力部分设置

            AgentStages.M_AY1 = datainit.MarketPromotionInit_AY1;
            AgentStages.M_AY2 = datainit.MarketPromotionInit_AY2;
            AgentStages.M_AX1 = datainit.MarketPromotionInit_AX1;
            AgentStages.M_AX2 = datainit.MarketPromotionInit_AX2;
            AgentStages.M_AX3 = datainit.MarketPromotionInit_AX3;
            AgentStages.M_AX4 = datainit.MarketPromotionInit_AX4;
            AgentStages.M_AX5 = datainit.MarketPromotionInit_AX5;
            AgentStages.M_AX6 = datainit.MarketPromotionInit_AX6;


            //渠道服务部分设置

            AgentStages.C_J1 = datainit.ChannelService_J1;
            AgentStages.C_J2 = datainit.ChannelService_J2;

            //市场价格部分设置

            AgentStages.MP_CD = datainit.CD;
            AgentStages.MP_CE = datainit.CE;
            AgentStages.MP_CF = datainit.CF;
            AgentStages.MP_CM = datainit.CM;
            AgentStages.MP_CN = datainit.CN;
            AgentStages.MP_CO = datainit.CO;

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
      
            var agentInputsFrist = agentInputs.Where(s => s.Stage == Common.Stage.起始阶段.ToString()
                  || s.Stage == Common.Stage.第1阶段.ToString()).OrderBy(s => s.AgentName).ToList();
                var brandsInputsFrist = brandsInputs.Where(s => s.Stage == Common.Stage.起始阶段.ToString()
                || s.Stage == Common.Stage.第1阶段.ToString()).OrderBy(s => s.Stage).ToList();
            if(agentInputsFrist == null||agentInputsFrist.Count == 0   )
                return Content($"<script>alert('代理数据不全：只有{agentInputsFrist.Count}个');location='" + Url.Action("index", "home") + "'</script>");
            if(brandsInputsFrist.Count!=3)
                return Content("<script>alert('品牌商不全，只有"+
                    string.Join(",",brandsInputsFrist.Select(s=>s.UserId).ToArray())+"');location='" + Url.Action("index", "home") + "'</script>");
                AgentStages.stages = AgentStages.stages.Take(2).ToList();
            if (agentInputsFrist != null && agentInputsFrist.Count > 0 && brandsInputsFrist != null && brandsInputsFrist.Count == 3)
            {
                invertmentTable1 = new InvertmentTable1(agentInputsFrist, brandsInputsFrist);
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
         
            var agentInputsFrist = agentInputs.Where(s => s.Stage == Common.Stage.起始阶段.ToString()
                  || s.Stage == Common.Stage.第1阶段.ToString() || s.Stage == Common.Stage.第2阶段.ToString()
                   || s.Stage == Common.Stage.第3阶段.ToString()).OrderBy(s => s.AgentName).ToList();
            var brandsInputsFrist = brandsInputs.Where(s => s.Stage == Common.Stage.起始阶段.ToString()
            || s.Stage == Common.Stage.第1阶段.ToString() || s.Stage == Common.Stage.第2阶段.ToString()
            || s.Stage == Common.Stage.第3阶段.ToString()).OrderBy(s => s.Stage).ToList();

          

            if (agentInputsFrist == null || agentInputsFrist.Count == 0 || agentInputsFrist.Count != (AgentStages.agents.IndexOf(agentInputsFrist.Select(s => s.AgentName).OrderByDescending(s => s).First()) + 1) * 2||brandsInputsFrist.Count != 9)
            {
                AgentStages.stages = AgentStages.stages.Take(3).ToList();
                  agentInputsFrist = agentInputs.Where(s => s.Stage == Common.Stage.起始阶段.ToString()
                      || s.Stage == Common.Stage.第1阶段.ToString() || s.Stage == Common.Stage.第2阶段.ToString()).OrderBy(s => s.AgentName).ToList();
                  brandsInputsFrist = brandsInputs.Where(s => s.Stage == Common.Stage.起始阶段.ToString()
                || s.Stage == Common.Stage.第1阶段.ToString() || s.Stage == Common.Stage.第2阶段.ToString()).OrderBy(s => s.Stage).ToList();
         

                if (agentInputsFrist == null || agentInputsFrist.Count == 0 || agentInputsFrist.Count != (AgentStages.agents.IndexOf(agentInputsFrist.Select(s => s.AgentName).OrderByDescending(s => s).First()) + 1) * 2||brandsInputsFrist.Count != 6)
                {
                    AgentStages.stages = AgentStages.stages.Take(2).ToList();
                      agentInputsFrist = agentInputs.Where(s => s.Stage == Common.Stage.起始阶段.ToString()
                          || s.Stage == Common.Stage.第1阶段.ToString()).OrderBy(s => s.AgentName).ToList();
                      brandsInputsFrist = brandsInputs.Where(s => s.Stage == Common.Stage.起始阶段.ToString()
                    || s.Stage == Common.Stage.第1阶段.ToString()).OrderBy(s => s.Stage).ToList();
                    if (agentInputsFrist == null)
                        return Content($"<script>alert('代理数据不全：只有{agentInputsFrist.Count}个');location='" + Url.Action("index", "home") + "'</script>");
                    if (brandsInputsFrist.Count != 3)
                        return Content("<script>alert('品牌商不全，只有" +
                            string.Join(",", brandsInputsFrist.Select(s => s.UserId).ToArray()) + "');location='" + Url.Action("index", "home") + "'</script>");

                }
            }
            AgentStages.stages = AgentStages.stages.Take(4).ToList();
            if (agentInputsFrist != null && agentInputsFrist.Count > 0 && brandsInputsFrist != null && brandsInputsFrist.Count > 0)
            {
                invertmentTable1 = new InvertmentTable1(agentInputsFrist, brandsInputsFrist);
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
        
            var agentInputsFrist = agentInputs.Where(s => s.Stage == Common.Stage.起始阶段.ToString()
                  || s.Stage == Common.Stage.第1阶段.ToString() || s.Stage == Common.Stage.第2阶段.ToString()).OrderBy(s => s.AgentName).ToList();
            var brandsInputsFrist = brandsInputs.Where(s => s.Stage == Common.Stage.起始阶段.ToString()
            || s.Stage == Common.Stage.第1阶段.ToString() || s.Stage == Common.Stage.第2阶段.ToString()).OrderBy(s => s.Stage).ToList();
         
            if (agentInputsFrist == null||agentInputsFrist.Count==0|| agentInputsFrist.Count!= (AgentStages.agents.IndexOf(agentInputsFrist.Select(s => s.AgentName).OrderByDescending(s => s).First()) + 1)*2)
                return Content($"<script>alert('代理数据不全：只有{agentInputsFrist.Count}个');location='" + Url.Action("index", "home") + "'</script>");
            if (brandsInputsFrist.Count != 6)
                return Content("<script>alert('品牌商不全，只有" +
                    string.Join(",", brandsInputsFrist.Select(s => s.UserId).ToArray()) + "');location='" + Url.Action("index", "home") + "'</script>");
            AgentStages.stages = AgentStages.stages.Take(3).ToList();
            if (agentInputs != null && agentInputs.Count > 0 && brandsInputs != null && brandsInputsFrist.Count > 0)
            {
                invertmentTable1 = new InvertmentTable1(agentInputsFrist, brandsInputsFrist);
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
           
           
            var agentInputsFrist = agentInputs.Where(s => s.Stage == Common.Stage.起始阶段.ToString()
                  || s.Stage == Common.Stage.第1阶段.ToString() || s.Stage == Common.Stage.第2阶段.ToString()
                   || s.Stage == Common.Stage.第3阶段.ToString()).OrderBy(s => s.AgentName).ToList();
            var brandsInputsFrist = brandsInputs.Where(s => s.Stage == Common.Stage.起始阶段.ToString()
            || s.Stage == Common.Stage.第1阶段.ToString() || s.Stage == Common.Stage.第2阶段.ToString()
            || s.Stage == Common.Stage.第3阶段.ToString()).OrderBy(s => s.Stage).ToList();

       

            if (agentInputsFrist == null ||agentInputsFrist.Count==0|| agentInputsFrist.Count != (AgentStages.agents.IndexOf(agentInputsFrist.Select(s => s.AgentName).OrderByDescending(s => s).First()) + 1) * 2)
                return Content($"<script>alert('代理数据不全：只有{agentInputsFrist.Count}个');location='" + Url.Action("index", "home") + "'</script>");
            if (brandsInputsFrist.Count != 6)
                return Content("<script>alert('品牌商不全，只有" +
                    string.Join(",", brandsInputsFrist.Select(s => s.UserId).ToArray()) + "');location='" + Url.Action("index", "home") + "'</script>");
            AgentStages.stages = AgentStages.stages.Take(4).ToList();
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