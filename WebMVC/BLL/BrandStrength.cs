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
        List<BrandTable> investMents;
        public BrandStrength()
        {
            investMents = new InvertmentTable1().getBrandsInputs(); 
            Init();
        }
        public void Init()
        {
            BrandStrengthTable initT = new BrandStrengthTable
            {
                ID = (int)Stage.起始阶段,
                Stage= "起始阶段",
                E = 33,
                F = 33,
                G = 33,
                H = 800,
                I = 800,
                J = 800
            };
            brandStrengths.Add(initT);
            foreach (var item in investMents)
            {
               var brandStrength = brandStrengths.FirstOrDefault(s => s.Stage == item.Stage);
                if (brandStrength == null)
                {
                    brandStrength = new BrandStrengthTable
                    {
                        ID = (int)Enum.Parse(typeof(Stage), item.Stage),
                        Stage = item.Stage,
                    };
                    brandStrengths.Add(brandStrength);
                }
                    Brand brand = (Brand)Enum.Parse(typeof(Brand), item.Brand);
                    switch (brand)
                    {
                        case Brand.M品牌:
                        brandStrength.H = item.advertise;
                            break;
                        case Brand.S品牌:
                        brandStrength.I = item.advertise;
                        break;
                        case Brand.J品牌:
                        brandStrength.J = item.advertise;
                        break;
                        default:
                            break;
                    }
                }
            SetCBPI(brandStrengths, brandStrengths.OrderByDescending(s => s.ID).Take(1).ToList()[0]);
            
        }
        private void SetCBPI(List<BrandStrengthTable> brands, BrandStrengthTable s)
        {
            Stage stage = (Stage)Enum.Parse(typeof(Stage), s.Stage);
            if (stage == Stage.起始阶段) return;
            int index = (int)Enum.Parse(typeof(Stage), s.Stage);
            var last = brands.FirstOrDefault(j => j.Stage == Enum.GetName(typeof(Stage), index - 1));
            SetCBPI(brands, last);
            s.E = Cal.CBPI(last.E, last.K, last.N, s.K, s.N);
            s.F = Cal.CBPI(last.F, last.L, last.N, s.L, s.N);
            s.G = Cal.CBPI(last.G, last.M, last.N, s.M, s.N);
       }


        public List<BrandStrengthTable> Get()
        {
            return brandStrengths;
        }
    }
    public class BrandStrengthTable
    {
        public int ID { get; set; }
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

        public decimal P
        {
            get
            {
                return B + C + D;
            }
        }
    }
}