using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.BLL
{
    /// <summary>
    /// 厂家主导的品牌力
    /// </summary>
    public class BrandStrength
    {
        private int brand_e;
        private int brand_h;


        List<BrandStrengthTable> brandStrengths = new List<BrandStrengthTable>();
        List<BrandTable> investMents;
        
        public BrandStrength(InvertmentTable1 invertmentTable1)
        {
            brand_e = AgentStages.BrandStrength_E;
            brand_h = AgentStages.BrandStrength_M1;
           
            investMents = invertmentTable1.getBrandTable();
  
            Init();
        }
        public void Init()
        {
            BrandStrengthTable initT = new BrandStrengthTable
            {

                ID = 0,
                Stage = AgentStages.stages[0],
                E = brand_e,
                F = brand_e,
                G = brand_e,
                H = brand_h,
                I = brand_h,
                J = brand_h
            };
            brandStrengths.Add(initT);
            foreach (var item in investMents)
            {
                var brandStrength = brandStrengths.FirstOrDefault(s => s.Stage == item.Stage);
                if (brandStrength == null)
                {
                    brandStrength = new BrandStrengthTable
                    {
                        ID = AgentStages.stages.IndexOf(item.Stage),
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
             int index =AgentStages.stages.IndexOf( s.Stage);
            if (index == 0) return;
             var last = brands.FirstOrDefault(j => j.Stage == AgentStages.stages[ index - 1]);
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
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public decimal B
        {
            get
            {
                return E + F + G == 0 ? 0 : E / (E + F + G);
            }
        }
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public decimal C
        {
            get
            {
                return E + F + G == 0 ? 0 : F / (E + F + G);
            }
        }
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public decimal D
        {
            get
            {
                return E + F + G == 0 ? 0 : G / (E + F + G);
            }
        }
        /// <summary>
        /// 品牌力指数 M
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal E { get; set; }
        /// <summary>
        /// 品牌力指数 S
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal F { get; set; }
        /// <summary>
        /// 品牌力指数 J
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal G { get; set; }
        /// <summary>
        /// 广告投放金额（包括大型活动投入）M
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal H { get; set; }
        /// <summary>
        /// 广告投放金额（包括大型活动投入）S
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal I { get; set; }
        /// <summary>
        /// 广告投放金额（包括大型活动投入）J
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public decimal J { get; set; }
        /// <summary>
        /// 广告投放指数 M
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public decimal K
        {
            get
            {
                return H + I + J == 0 ? 0 : H / (H + I + J);
            }
        }
        /// <summary>
        /// 广告投放指数 S
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public decimal L
        {
            get
            {
                return H + I + J == 0 ? 0 : I / (H + I + J);
            }
        }
        /// <summary>
        /// 广告投放指数 M
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public decimal M
        {
            get
            {
                return H + I + J == 0 ? 0 : J / (H + I + J);
            }
        }
        /// <summary>
        /// 广告投放指数的平均指数
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public decimal N
        {
            get
            {
                return (K + L + M) / 3;
            }
        }
        [DisplayFormat(DataFormatString = "{0:P1}")]
        public decimal P
        {
            get
            {
                return B + C + D;
            }
        }
    }
}