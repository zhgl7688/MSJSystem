using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;

namespace WebMVC.BLL
{
    /// <summary>
    /// 最终三个品牌的市场占有率
    /// </summary>
    public class LastBrand
    {
        List<LastBrandTable> lastBrands = new List<LastBrandTable>();
        List<CurrentShareTable> currentShares;
        int count; 
        public LastBrand(CurrentShare CurrentShare, int count)
        {
            this.currentShares = CurrentShare.Get();
            this.count = count;
            Init();
        }
        private void Init()
        {
            LastBrandTable lastBrandTableM = new LastBrandTable { Brand = Brand.M品牌.ToString() };
            LastBrandTable lastBrandTableS = new LastBrandTable { Brand = Brand.S品牌.ToString() };
            LastBrandTable lastBrandTableJ = new LastBrandTable { Brand = Brand.J品牌.ToString() };
            lastBrands.Add(lastBrandTableM);
            lastBrands.Add(lastBrandTableS);
            lastBrands.Add(lastBrandTableJ);


         
            foreach (var item in currentShares)
            {
                Stage stage = (Stage)Enum.Parse(typeof(Stage), item.Stage);
                switch (stage)
                {
                    case Stage.起始阶段:
                        lastBrandTableM.B = item.H[1].M.Average();
                        lastBrandTableS.B = item.AR[1].Agent.Average();
                        lastBrandTableJ.B = item.Z[1].J.Average();
                        break;
                    case Stage.第一阶段:
                        lastBrandTableM.C = Common.Cal.GetMJAAverage(item.H[1], count, MJAType.M);
                        lastBrandTableS.C = Common.Cal.GetMJAAverage(item.AR[1], count, MJAType.Agent);
                        lastBrandTableJ.C = Common.Cal.GetMJAAverage(item.Z[1], count, MJAType.J);
                        break;
                    case Stage.第二阶段:
                        lastBrandTableM.D = Common.Cal.GetMJAAverage(item.H[1], count, MJAType.M);
                        lastBrandTableS.D = Common.Cal.GetMJAAverage(item.AR[1], count, MJAType.Agent);
                        lastBrandTableJ.D = Common.Cal.GetMJAAverage(item.Z[1], count, MJAType.J);
                        lastBrandTableM.E = Common.Cal.GetMJAAverage(item.H[2], count, MJAType.M);
                        lastBrandTableS.E = Common.Cal.GetMJAAverage(item.AR[2], count, MJAType.Agent);
                        lastBrandTableJ.E = Common.Cal.GetMJAAverage(item.Z[2], count, MJAType.J);
                        break;
                    case Stage.第三阶段:
                        lastBrandTableM.F = Common.Cal.GetMJAAverage(item.H[1], count, MJAType.M);
                        lastBrandTableS.F = Common.Cal.GetMJAAverage(item.AR[1], count, MJAType.Agent);
                        lastBrandTableJ.F = Common.Cal.GetMJAAverage(item.Z[1], count, MJAType.J);
                        lastBrandTableM.G = Common.Cal.GetMJAAverage(item.H[2], count, MJAType.M);
                        lastBrandTableS.G = Common.Cal.GetMJAAverage(item.AR[2], count, MJAType.Agent);
                        lastBrandTableJ.G = Common.Cal.GetMJAAverage(item.Z[2], count, MJAType.J);
                        lastBrandTableM.H = Common.Cal.GetMJAAverage(item.H[3], count, MJAType.M);
                        lastBrandTableS.H = Common.Cal.GetMJAAverage(item.AR[3], count, MJAType.Agent);
                        lastBrandTableJ.H = Common.Cal.GetMJAAverage(item.Z[3], count, MJAType.J);
                         break;
                    default:
                        break;
                }
            }
        }
        public List<LastBrandTable> Get()
        {
            return lastBrands;

        }
    }
    public class LastBrandTable
    {
        public string Brand { get; internal set; }
        public decimal B { get; set; }
        public decimal C { get; set; }
        public decimal D { get; set; }
        public decimal E { get; set; }
        public decimal F { get; set; }
        public decimal G { get; set; }
        public decimal H { get; set; }
    }
}