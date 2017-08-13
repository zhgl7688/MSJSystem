using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public class ProductInnovation
    {
        List<ProductInnvoationTable> productInnvoations = new List<ProductInnvoationTable>();
        List<BrandStrengthTable> brandStrengths;
        List<BrandTable> investments;
        /// <summary>
        ///  厂家主导的产品创新力
        /// </summary>
        public ProductInnovation(BrandStrength brandStrength, InvertmentTable1 invertmentTable1)
        {
            brandStrengths =brandStrength.Get();
            investments = invertmentTable1.getBrandTable();
            Init();
        }
        RC initRC = new RC{
                M = 0.35m,
                S = 0.45m,
                J = 0.20m,
            };
        private void Init()
        {
            #region 起始阶段
            var brandStrength0 = brandStrengths.FirstOrDefault(s => s.Stage == Stage.起始阶段.ToString());
           
            ProductInnvoationTable initT = new ProductInnvoationTable()
            {
                Stage = brandStrength0.Stage,ID=(int)Stage.起始阶段
            };
            initT.K.RC1 = new RC
            {
                M = 0.35m,
                S = 0.45m,
                J = 0.20m,
            };

            initT.T.RC1.M = (1000 - brandStrength0.H) * 0.3m;
            initT.T.RC1.S = (1000 - brandStrength0.I) * 0.3m;
            initT.T.RC1.J = (1000 - brandStrength0.J) * 0.3m;

            initT.AC.RC1.M = (1000 - brandStrength0.H) * 0.5m;
            initT.AC.RC1.S = (1000 - brandStrength0.I) * 0.5m;
            initT.AC.RC1.J = (1000 - brandStrength0.J) * 0.5m;

            initT.AL.RC1.M = (1000 - brandStrength0.H) * 0.2m;
            initT.AL.RC1.S = (1000 - brandStrength0.I) * 0.2m;
            initT.AL.RC1.J = (1000 - brandStrength0.J) * 0.2m;

            initT.PTCal();
            productInnvoations.Add(initT);
            #endregion
            foreach (var item in investments)
            {
   
                var productInnvoation = productInnvoations.FirstOrDefault(s => s.Stage == item.Stage);
                if (productInnvoation == null)
                {

                    productInnvoation = new ProductInnvoationTable()
                    {
                        Stage = item.Stage,ID=(int)Enum.Parse(typeof(Stage),item.Stage)
                    };
                    productInnvoations.Add(productInnvoation);
                }
                Brand brand = (Brand)Enum.Parse(typeof(Brand), item.Brand);
                switch (brand)
                {
                    case Brand.M品牌:
                        productInnvoation.T.RC1.M = item.SurfaceRC1;
                        productInnvoation.AC.RC1.M = item.FunctionRC1;
                        productInnvoation.AL.RC1.M = item.MaterialRC1;
                        productInnvoation.T.RC2.M = item.SurfaceRC2;
                        productInnvoation.AC.RC2.M = item.FunctionRC2;
                        productInnvoation.AL.RC2.M = item.MaterialRC2;
                        productInnvoation.T.RC3.M = item.SurfaceRC3;
                        productInnvoation.AC.RC3.M = item.FunctionRC3;
                        productInnvoation.AL.RC3.M = item.MaterialRC3;
                        break;
                    case Brand.S品牌:
                        productInnvoation.T.RC1.S = item.SurfaceRC1;
                        productInnvoation.AC.RC1.S = item.FunctionRC1;
                        productInnvoation.AL.RC1.S= item.MaterialRC1;
                        productInnvoation.T.RC2.S = item.SurfaceRC2;
                        productInnvoation.AC.RC2.S = item.FunctionRC2;
                        productInnvoation.AL.RC2.S = item.MaterialRC2;
                        productInnvoation.T.RC3.S = item.SurfaceRC3;
                        productInnvoation.AC.RC3.S = item.FunctionRC3;
                        productInnvoation.AL.RC3.S = item.MaterialRC3;
                        break;
                    case Brand.J品牌:
                        productInnvoation.T.RC1.J = item.SurfaceRC1;
                        productInnvoation.AC.RC1.J = item.FunctionRC1;
                        productInnvoation.AL.RC1.J = item.MaterialRC1;
                        productInnvoation.T.RC2.J = item.SurfaceRC2;
                        productInnvoation.AC.RC2.J = item.FunctionRC2;
                        productInnvoation.AL.RC2.J = item.MaterialRC2;
                        productInnvoation.T.RC3.J = item.SurfaceRC3;
                        productInnvoation.AC.RC3.J = item.FunctionRC3;
                        productInnvoation.AL.RC3.J = item.MaterialRC3;

                        break;
                    default:
                        break;
                }
            }
            SetInvovation(productInnvoations, productInnvoations.OrderByDescending(s => s.ID).Take(1).ToList()[0]);

        }
        private void SetInvovation(List<ProductInnvoationTable> products, ProductInnvoationTable product)
        {
            Stage stage = (Stage)Enum.Parse(typeof(Stage), product.Stage);
            if (stage == Stage.起始阶段) return;
            int index = (int)Enum.Parse(typeof(Stage), product.Stage);
            var last = products.FirstOrDefault(j => j.Stage == Enum.GetName(typeof(Stage), index - 1));
            SetInvovation(products, last);
            product.K.RC1.M = last.InnovationIndexR1M;
            product.K.RC1.S = last.InnovationIndexR1S;
            product.K.RC1.J = last.InnovationIndexR1J;

            if (stage == Stage.第二阶段 )
            {
                product.K.RC2 = new RC
                {
                    M = 0.35m,
                    S = 0.45m,
                    J = 0.20m,
                };
            }
            if (stage == Stage.第三阶段)
            {
                product.K.RC2.M = last.InnovationIndexR2M;
                product.K.RC2.S = last.InnovationIndexR2S;
                product.K.RC2.J = last.InnovationIndexR2J;
                product.K.RC3 = new RC
                {
                    M = 0.35m,
                    S = 0.45m,
                    J = 0.20m,
                };
            }
            product.PTCal();
        }
        public List<ProductInnvoationTable> Get()
        {
            return productInnvoations;
        }
    }
    public class ProductInnvoationTable
    {
        public int ID { get; set; }

        public void PTCal()
        {

            #region 创新影响力
            B.RC1.M = K.RC1.Percent(1);
            B.RC1.S = K.RC1.Percent(2);
            B.RC1.J = K.RC1.Percent(3);
            B.RC2.M = K.RC2.Percent(1);
            B.RC2.S = K.RC2.Percent(2);
            B.RC2.J = K.RC2.Percent(3);
            B.RC3.M = K.RC3.Percent(1);
            B.RC3.S = K.RC3.Percent(2);
            B.RC3.J = K.RC3.Percent(3);
            #endregion

            #region 创新投入合计
            AU.RC1.M = T.RC1.M + AC.RC1.M + AL.RC1.M;
            AU.RC1.S = T.RC1.S + AC.RC1.S + AL.RC1.S;
            AU.RC1.J = T.RC1.J + AC.RC1.J + AL.RC1.J;

            AU.RC2.M = T.RC2.M + AC.RC2.M + AL.RC2.M;
            AU.RC2.S = T.RC2.S + AC.RC2.S + AL.RC2.S;
            AU.RC2.J = T.RC2.J + AC.RC2.J + AL.RC2.J;

            AU.RC3.M = T.RC3.M + AC.RC3.M + AL.RC3.M;
            AU.RC3.S = T.RC3.S + AC.RC3.S + AL.RC3.S;
            AU.RC3.J = T.RC3.J + AC.RC3.J + AL.RC3.J;
            #endregion

            #region 外观创新指数
            BD.RC1.M = T.RC1.Percent(1);
            BD.RC1.S = T.RC1.Percent(2);
            BD.RC1.J = T.RC1.Percent(3);
            BD.RC2.M = T.RC2.Percent(1);
            BD.RC2.S = T.RC2.Percent(2);
            BD.RC2.J = T.RC2.Percent(3);
            BD.RC3.M = T.RC3.Percent(1);
            BD.RC3.S = T.RC3.Percent(2);
            BD.RC3.J = T.RC3.Percent(3);
            #endregion

            #region 功能创新指数
            BP.RC1.M = AC.RC1.Percent(1);
            BP.RC1.S = AC.RC1.Percent(2);
            BP.RC1.J = AC.RC1.Percent(3);

            BP.RC2.M = AC.RC2.Percent(1);
            BP.RC2.S = AC.RC2.Percent(2);
            BP.RC2.J = AC.RC2.Percent(3);

            BP.RC3.M = AC.RC3.Percent(1);
            BP.RC3.S = AC.RC3.Percent(2);
            BP.RC3.J = AC.RC3.Percent(3);
            #endregion

            #region 产出系数
            CB.RC1.M = T.RC1.OutputCoefficient(1);
            CB.RC1.S = T.RC1.OutputCoefficient(2);
            CB.RC1.J = T.RC1.OutputCoefficient(3);

            CB.RC2.M = T.RC2.OutputCoefficient(1);
            CB.RC2.S = T.RC2.OutputCoefficient(2);
            CB.RC2.J = T.RC2.OutputCoefficient(3);

            CB.RC3.M = T.RC3.OutputCoefficient(1);
            CB.RC3.S = T.RC3.OutputCoefficient(2);
            CB.RC3.J = T.RC3.OutputCoefficient(3);
            #endregion



        }
        public decimal InnovationIndexR1M
        {
            get
            {
                return Cal.InnovationIndex(K.RC1.M, BD.RC1.M, BD.RC1.Average, CB.RC1.M, BP.RC1.M, BP.RC1.Average, CK.RC1.M);
            }
        }
        public decimal InnovationIndexR1S
        {
            get
            {
                return Cal.InnovationIndex(K.RC1.S, BD.RC1.S, BD.RC1.Average, CB.RC1.S, BP.RC1.S, BP.RC1.Average, CK.RC1.S);
            }
        }
        public decimal InnovationIndexR1J
        {
            get
            {
                return Cal.InnovationIndex(K.RC1.J, BD.RC1.J, BD.RC1.Average, CB.RC1.J, BP.RC1.J, BP.RC1.Average, CK.RC1.J);
            }
        }
        public decimal InnovationIndexR2M
        {
            get
            {
                return Cal.InnovationIndex(K.RC2.M, BD.RC2.M, BD.RC2.Average, CB.RC2.M, BP.RC2.M, BP.RC2.Average, CK.RC2.M);
            }
        }
        public decimal InnovationIndexR2S
        {
            get
            {
                return Cal.InnovationIndex(K.RC2.S, BD.RC2.S, BD.RC2.Average, CB.RC2.S, BP.RC2.S, BP.RC2.Average, CK.RC2.S);
            }
        }
        public decimal InnovationIndexR2J
        {
            get
            {
                return Cal.InnovationIndex(K.RC2.J, BD.RC2.J, BD.RC2.Average, CB.RC2.J, BP.RC2.J, BP.RC2.Average, CK.RC2.J);
            }
        }
        public decimal InnovationIndexR3M
        {
            get
            {
                return Cal.InnovationIndex(K.RC3.M, BD.RC3.M, BD.RC3.Average, CB.RC3.M, BP.RC3.M, BP.RC3.Average, CK.RC3.M);
            }
        }
        public decimal InnovationIndexR3S
        {
            get
            {
                return Cal.InnovationIndex(K.RC3.S, BD.RC3.S, BD.RC3.Average, CB.RC3.S, BP.RC3.S, BP.RC3.Average, CK.RC3.S);
            }
        }
        public decimal InnovationIndexR3J
        {
            get
            {
                return Cal.InnovationIndex(K.RC3.J, BD.RC3.J, BD.RC3.Average, CB.RC3.J, BP.RC3.J, BP.RC3.Average, CK.RC3.J);
            }
        }
        public string Stage { get; set; }
        /// <summary>
        /// 创新影响力
        /// </summary>
        public InnovationImpact B { get; set; } = new InnovationImpact();
        /// <summary>
        /// 创新指数
        /// </summary>
        public InnovationIndex K { get; set; } = new InnovationIndex();
        /// <summary>
        /// 外观创新投入
        /// </summary>
        public AppearanceInvestment T { get; set; } = new AppearanceInvestment();
        /// <summary>
        /// 功能创新投入
        /// </summary>
        public FunctionInvestment AC { get; set; } = new FunctionInvestment();
        /// <summary>
        /// 材料创新投入
        /// </summary>
        public MaterialInvestment AL { get; set; } = new MaterialInvestment();
        /// <summary>
        /// 投入合计
        /// </summary>
        public InvestmentSum AU { get; set; } = new InvestmentSum();
        /// <summary>
        /// 外观创新指数
        /// </summary>
        public AppearanceInnovationIndex BD { get; set; } = new AppearanceInnovationIndex();
        /// <summary>
        /// 功能创新指数	
        /// </summary>
        public FunctionInnovationIndex BP { get; set; } = new FunctionInnovationIndex();
        /// <summary>
        /// 外观创新产出
        /// </summary>
        public AppearanceOutput CB { get; set; } = new AppearanceOutput();
        /// <summary>
        /// 功能创新产出
        /// </summary>
        public FunctionOutput CK
        {
            get
            {
                var result = new FunctionOutput();
                result.RC1 = GetCK(AC.RC1);
                result.RC2 = GetCK(AC.RC2);
                result.RC3 = GetCK(AC.RC3);
                return result;
            }
        }
        private RC GetCK(RC rc)
        {
            var m = rc.M;
            var s = rc.S;
            var j = rc.J;
            var Averaget = rc.Average;

            //=IF(AND(AC5>AD5,AC5>ae),1.3,IF(AND(AC5<AD5,AC5<ae),(0.7),IF(AC5>AVERAGE(AC5:ae),1.15,IF(AC5=AVERAGE(AC5:ae),1,0.85))))
            return new RC
            {
                M = m > s && m > j ? 1.3m : m < s && m < j ? 0.7m : m > Averaget ? 1.15m : m == Averaget ? 1 : 0.85m,
                S = s > j && s > m ? 1.3m : s < j && s < m ? 0.7m : s > Averaget ? 1.15m : s == Averaget ? 1 : 0.85m,
                J = j > m && j > s ? 1.3m : j < m && j < s ? 0.7m : j > Averaget ? 1.15m : j == Averaget ? 1 : 0.85m
            };
        }
        /// <summary>
        /// 材料创新带来的利润系数
        /// </summary>
        public ProfitFactor CT
        {
            get
            {
                var result = new ProfitFactor();
                result.RC1.M = AL.RC1.M / 100 * 0.02M;
                result.RC1.S = AL.RC1.S / 100 * 0.02M;
                result.RC1.J = AL.RC1.J / 100 * 0.02M;
                result.RC2.M = AL.RC2.M / 100 * 0.02M;
                result.RC2.S = AL.RC2.S / 100 * 0.02M;
                result.RC2.J = AL.RC2.J / 100 * 0.02M;
                result.RC3.M = AL.RC3.M / 100 * 0.02M;
                result.RC3.S = AL.RC3.S / 100 * 0.02M;
                result.RC3.J = AL.RC3.J / 100 * 0.02M;
                return result;
            }
        }

        public decimal DD
        {
            get
            {
                return B.RC1.Sum;

            }
        }
        public decimal DE
        {
            get
            {
                return B.RC2.Sum;

            }
        }
        public decimal DF
        {
            get
            {
                return B.RC3.Sum;

            }
        }
    }
    public class InnovationImpact
    {
        public RC RC1 { get; set; } = new RC();
        public RC RC2 { get; set; } = new RC();
        public RC RC3 { get; set; } = new RC();
    }
    public class InnovationIndex
    {
        public RC RC1 { get; set; } = new RC();
        public RC RC2 { get; set; } = new RC();
        public RC RC3 { get; set; } = new RC();
    }
    public class AppearanceInvestment
    {
        public RC RC1 { get; set; } = new RC();
        public RC RC2 { get; set; } = new RC();
        public RC RC3 { get; set; } = new RC();
    }
    public class FunctionInvestment
    {
        public RC RC1 { get; set; } = new RC();
        public RC RC2 { get; set; } = new RC();
        public RC RC3 { get; set; } = new RC();
    }
    public class MaterialInvestment
    {
        public RC RC1 { get; set; } = new RC();
        public RC RC2 { get; set; } = new RC();
        public RC RC3 { get; set; } = new RC();
    }
    public class InvestmentSum
    {
        public RC RC1 { get; set; } = new RC();
        public RC RC2 { get; set; } = new RC();
        public RC RC3 { get; set; } = new RC();
    }

    public class AppearanceInnovationIndex
    {
        public RC RC1 { get; set; } = new RC();
        public RC RC2 { get; set; } = new RC();
        public RC RC3 { get; set; } = new RC();
    }
    public class AppearanceOutput
    {
        public RC RC1 { get; set; } = new RC();
        public RC RC2 { get; set; } = new RC();
        public RC RC3 { get; set; } = new RC();
    }
    public class FunctionInnovationIndex
    {
        public RC RC1 { get; set; } = new RC();
        public RC RC2 { get; set; } = new RC();
        public RC RC3 { get; set; } = new RC();
    }
    public class FunctionOutput
    {
        public RC RC1 { get; set; } = new RC();
        public RC RC2 { get; set; } = new RC();
        public RC RC3 { get; set; } = new RC();
    }
    public class ProfitFactor
    {
        public RC RC1 { get; set; } = new RC();
        public RC RC2 { get; set; } = new RC();
        public RC RC3 { get; set; } = new RC();
    }

}