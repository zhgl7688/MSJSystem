using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;

namespace WebMVC.BLL
{
    /// <summary>
    /// 厂家主导的品牌力
    /// </summary>
    public class BrandStrength
    {
        List<BrandStrengthTable> brandStrengths = new List<BrandStrengthTable>();
        List<InvestmentTable> investMents;
        public BrandStrength()
        {
              investMents = new Investment().Get();
            Init();
        }
        public void Init()
        {
            BrandStrengthTable initT = new BrandStrengthTable
            {
                Stage= "起始阶段",
                E = 33,
                F = 33,
                G = 33,
                H = 800,
                I = 800,
                J = 800
            };
            brandStrengths.Add(initT);
            var investMent1 = investMents.FirstOrDefault(s => s.Stage == Enum.GetName(typeof(Stage), Stage.第一阶段));
            if (investMent1!=null)
            {
                BrandStrengthTable bst1 = GetBrandStrenthT(initT, investMent1);
                brandStrengths.Add(bst1);
                var investMent2 = investMents.FirstOrDefault(s => s.Stage == Enum.GetName(typeof(Stage), Stage.第二阶段));
                if (investMent2 != null)
                {
                    BrandStrengthTable bst2 = GetBrandStrenthT(bst1, investMent1);
                    brandStrengths.Add(bst2);
                    var investMent3= investMents.FirstOrDefault(s => s.Stage == Enum.GetName(typeof(Stage), Stage.第三阶段));
                    if (investMent3 != null)
                    {
                        BrandStrengthTable bst3 = GetBrandStrenthT(bst2, investMent1);
                        brandStrengths.Add(bst3);

                    }
                }
            }


        }

        private static BrandStrengthTable GetBrandStrenthT(BrandStrengthTable initT, InvestmentTable investMent1)
        {
            BrandStrengthTable bst1 = new BrandStrengthTable
            {
                Stage = Enum.GetName(typeof(Stage), Stage.第一阶段),
                H = investMent1.J,
                I = investMent1.K,
                J = investMent1.L,
            };
            bst1.E = Cal.CBPI(initT.E, initT.K, initT.N, bst1.K, bst1.N);
            bst1.F = Cal.CBPI(initT.F, initT.L, initT.N, bst1.L, bst1.N);
            bst1.G = Cal.CBPI(initT.G, initT.M, initT.N, bst1.M, bst1.N);
            return bst1;
        }

        public List<BrandStrengthTable> Get()
        {
            return brandStrengths;
        }
    }
    public class BrandStrengthTable
    {
        public string Stage { get; set; }
        public decimal B
        {
            get
            {
                return E / (E + F + G);
            }
        }
        public decimal C
        {
            get
            {
                return F / (E + F + G);
            }
        }
        public decimal D
        {
            get
            {
                return G / (E + F + G);
            }
        }
        /// <summary>
        /// 品牌力指数 M
        /// </summary>
        public decimal E { get; set; }
        /// <summary>
        /// 品牌力指数 S
        /// </summary>
        public decimal F { get; set; }
        /// <summary>
        /// 品牌力指数 J
        /// </summary>
        public decimal G { get; set; }
        /// <summary>
        /// 广告投放金额（包括大型活动投入）M
        /// </summary>
        public decimal H { get; set; }
        /// <summary>
        /// 广告投放金额（包括大型活动投入）S
        /// </summary>
        public decimal I { get; set; }
        /// <summary>
        /// 广告投放金额（包括大型活动投入）J
        /// </summary>
        public decimal J { get; set; }
        /// <summary>
        /// 广告投放指数 M
        /// </summary>
        public decimal K
        {
            get
            {
                return H / (H + I + J);
            }
        }
        /// <summary>
        /// 广告投放指数 S
        /// </summary>
        public decimal L {
            get
            {
                return I/ (H + I + J);
            }
        }
        /// <summary>
        /// 广告投放指数 M
        /// </summary>
        public decimal M {
            get
            {
                return J/ (H + I + J);
            }
        }
        /// <summary>
        /// 广告投放指数的平均指数
        /// </summary>
        public decimal N {
            get
            {
                return  (K + L + M)/3;
            }
        }


    }
}