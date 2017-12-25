using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.BLL;
using WebMVC.Infrastructure;

namespace MSJTest
{
    public class BaseTest
    {
        public InvertmentTable1 invertmentTable1;
        public BrandStrength brandStrength;
        public PriceControl priceControl;
        public ProductInnovation productInnovation;
        public CurrentShare currentShare;
        public StockReport stockReport;
        public Investment investment;
        public MarketPrice marketPrice;
        public IntentionIndex intentionIndex;
        public MarketPromotion marketPromotion;
        public ChannelService channelService;
        public MarketPriceTemp marketPriceTemp;
        public FirstPPT firstPPT;
        public SummaryAssent summaryAssent;
        public InvoicingReport invoicingReport;
        public LastBrand lastBrand;
        public SecondPPT secondPPT;
        public ThirdPPT thirdPPT;
        public BaseTest()
        {
            // AppIdentityDbContext db = new AppIdentityDbContext();
            // var agentInputs = db.AgentInputs.Where(s=>s.UserId=="11").ToList();
            // var brandsInputs = db.BrandsInputs.ToList();
            // var agentInputs = new ExampleData().agentInputs.Where(s => s.UserId == "11").ToList();
            var agentInputs = new ExampleData().agentInputs.ToList();
            var brandsInputs = new ExampleData().brands.ToList();
            invertmentTable1 = new InvertmentTable1(agentInputs, brandsInputs);
            priceControl = new PriceControl(invertmentTable1);
            brandStrength = new BrandStrength(invertmentTable1);
            channelService = new ChannelService(invertmentTable1);
            marketPromotion = new MarketPromotion(invertmentTable1);
            productInnovation = new ProductInnovation(brandStrength, invertmentTable1);
            marketPriceTemp = new MarketPriceTemp(priceControl);
            intentionIndex = new IntentionIndex(brandStrength, productInnovation, marketPromotion, channelService, marketPriceTemp);

            currentShare = new CurrentShare(intentionIndex, priceControl);
            marketPrice = new MarketPrice(priceControl, productInnovation, currentShare);

            stockReport = new StockReport(invertmentTable1, marketPrice);
            investment = new Investment(invertmentTable1, stockReport);
            invoicingReport = new InvoicingReport(currentShare, marketPrice, stockReport);



       summaryAssent = new SummaryAssent(stockReport, invoicingReport, marketPrice, investment, currentShare);
            //lastBrand = new LastBrand(currentShare,invertmentTable1.GetAgentCount);
            //firstPPT = new FirstPPT(marketPrice, investment, invertmentTable1, summaryAssent, lastBrand, invoicingReport,priceControl);
            //secondPPT = new SecondPPT(marketPrice, investment, invertmentTable1, summaryAssent, lastBrand, invoicingReport, priceControl, currentShare, firstPPT);
            //thirdPPT = new ThirdPPT(marketPrice, investment, invertmentTable1, summaryAssent, lastBrand, invoicingReport, priceControl, currentShare, secondPPT);
        }
    }
}
