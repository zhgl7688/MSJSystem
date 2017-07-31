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
        List<InvestmentTable> investments;
        public ProductInnovation()
        {
            brandStrengths = new BrandStrength().Get();
            investments = new Investment().Get();
            Init();
        }
        private void Init()
        {
            #region 起始阶段
            var brandStrength0 = brandStrengths.FirstOrDefault(s => s.Stage == Stage.起始阶段.ToString());
            var initRC = new RC
            {
                M = 0.35m,
                S = 0.45m,
                J = 0.20m,
            };
            ProductInnvoationTable initT = new ProductInnvoationTable()
            {
                Stage = brandStrength0.Stage,
            };
            initT.K.RC1 = initRC;

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

            var brandStrength1 = brandStrengths.FirstOrDefault(s => s.Stage == Stage.第一阶段.ToString());
            var investment1 = investments.FirstOrDefault(s => s.Stage == Stage.第一阶段.ToString());
            if (investment1 != null && brandStrength1 != null)
            {
                var T1 = productInnvoations.FirstOrDefault(s => s.Stage == Stage.第一阶段.ToString());

                if (T1 == null)
                {

                    T1 = new ProductInnvoationTable()
                    {
                        Stage = brandStrength1.Stage,
                    };
                    productInnvoations.Add(T1);
                }
                T1.K.RC1.M = initT.InnovationIndexR1M;
                T1.K.RC1.S = initT.InnovationIndexR1S;
                T1.K.RC1.J = initT.InnovationIndexR1J;
                T1.T.RC1.M = investment1.M.SurfaceRC1;
                T1.T.RC1.S = investment1.P.SurfaceRC1;
                T1.T.RC1.J = investment1.S.SurfaceRC1;

                T1.AC.RC1.M = investment1.N.FunctionRC1;
                T1.AC.RC1.S = investment1.Q.FunctionRC1;
                T1.AC.RC1.J = investment1.T.FunctionRC1;

                T1.AL.RC1.M = investment1.O.materialRC1;
                T1.AL.RC1.S = investment1.R.materialRC1;
                T1.AL.RC1.J = investment1.U.materialRC1;

                T1.PTCal();


            }




        }
        public List<ProductInnvoationTable> Get()
        {
            return productInnvoations;
        }
    }
    public class ProductInnvoationTable
    {
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
            BD.RC2.M = T.RC1.Percent(1);
            BD.RC2.S = T.RC1.Percent(2);
            BD.RC2.J = T.RC1.Percent(3);
            BD.RC3.M = T.RC1.Percent(1);
            BD.RC3.S = T.RC1.Percent(2);
            BD.RC3.J = T.RC1.Percent(3);
            #endregion

            #region 功能创新指数
            BP.RC1.M = AC.RC1.Percent(1);
            BP.RC1.S = AC.RC1.Percent(2);
            BP.RC1.J = AC.RC1.Percent(3);

            BP.RC2.M = AC.RC1.Percent(1);
            BP.RC2.S = AC.RC1.Percent(2);
            BP.RC2.J = AC.RC1.Percent(3);

            BP.RC3.M = AC.RC1.Percent(1);
            BP.RC3.S = AC.RC1.Percent(2);
            BP.RC3.J = AC.RC1.Percent(3);
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

            #region 材料创新带来的利润系数
            CT.RC1.M = AL.RC1.M / 100 * 0.2M;
            CT.RC1.S = AL.RC1.S / 100 * 0.2M;
            CT.RC1.J = AL.RC1.J / 100 * 0.2M;

            CT.RC2.M = AL.RC2.M / 100 * 0.2M;
            CT.RC2.S = AL.RC2.S / 100 * 0.2M;
            CT.RC2.J = AL.RC2.J / 100 * 0.2M;

            CT.RC3.M = AL.RC3.M / 100 * 0.2M;
            CT.RC3.S = AL.RC3.S / 100 * 0.2M;
            CT.RC3.J = AL.RC3.J / 100 * 0.2M;
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
        public FunctionOutput CK { get; set; } = new FunctionOutput();
        /// <summary>
        /// 材料创新带来的利润系数
        /// </summary>
        public ProfitFactor CT { get; set; } = new ProfitFactor();
        public decimal DD
        {
            get
            {
                return B.RC1.Sum;

            }
        }
        public decimal DE {
            get
            {
                return B.RC2.Sum;

            }
        }
        public decimal DF {
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