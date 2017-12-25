using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.Infrastructure;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public class ProductInnovation
    {
        List<ProductInnvoationTable> productInnvoations = new List<ProductInnvoationTable>();
        List<BrandStrengthTable> brandStrengths;
        List<BrandTable> brandTables;
        AgentStages agentStages;
        ProductInnovationInit piinit;
        RC initRC;
        /// <summary>
        ///  厂家主导的产品创新力
        /// </summary>
        public ProductInnovation(BrandStrength brandStrength, InvertmentTable1 invertmentTable1)
        {
            agentStages = new AgentStages();
            brandStrengths = brandStrength.Get();
            brandTables = invertmentTable1.getBrandTable();
            Init();
        }

        private void Init()
        {

            using (var db = new AppIdentityDbContext())
            {
                piinit = db.ProductInnovationInit.First();

                if (piinit == null) return;

            }
            initRC = new RC
            {
                M = piinit.ProductInnovation_M,//  .0.35m,
                S = piinit.ProductInnovation_S,//; 0.45m,
                J = piinit.ProductInnovation_J,// 0.20m,
            };
            #region 起始阶段
            var brandStrength0 = brandStrengths.FirstOrDefault(s => s.Stage == agentStages.stages[0]);

            ProductInnvoationTable initT = new ProductInnvoationTable()
            {
                Stage = agentStages.stages[0],
                ID = 0,
            };
      
            for (int i = 0; i < agentStages.stages.Count-1; i++)
            {
                if (i == 0)
                {   initT.K.IIXRC.Add(initRC);
                    initT.T.AIRC.Add(new RC
                    {
                        M = (1000 - brandStrength0.H) * piinit.ProductInnovation_T,// 0.3m;
                        S = (1000 - brandStrength0.I) * piinit.ProductInnovation_T,// 0.3m;
                        J = (1000 - brandStrength0.J) * piinit.ProductInnovation_T// 0.3m;
                    });
                    initT.AC.FIRC.Add(new RC());
                    initT.AC.FIRC[0].M = (1000 - brandStrength0.H) * piinit.ProductInnovation_AC;// 0.5m;
                    initT.AC.FIRC[0].S = (1000 - brandStrength0.I) * piinit.ProductInnovation_AC;//
                    initT.AC.FIRC[0].J = (1000 - brandStrength0.J) * piinit.ProductInnovation_AC;//
                    initT.AL.MIRC.Add(new RC());
                    initT.AL.MIRC[0].M = (1000 - brandStrength0.H) * piinit.ProductInnovation_AL;//0.2m;
                    initT.AL.MIRC[0].S = (1000 - brandStrength0.I) * piinit.ProductInnovation_AL;//0.2m;
                    initT.AL.MIRC[0].J = (1000 - brandStrength0.J) * piinit.ProductInnovation_AL;//0.2m;
                }
                else
                {
                    initT.K.IIXRC.Add(new RC() { J = 0, M = 0, S = 0 });
                    initT.T.AIRC.Add(new RC() { J = 0, M = 0, S = 0 });
                    initT.AC.FIRC.Add(new RC() { J = 0, M = 0, S = 0 });
                    initT.AL.MIRC.Add(new RC() { J = 0, M = 0, S = 0 });
                }
            }

            initT.PTCal();
            productInnvoations.Add(initT);
            #endregion
            foreach (var item in brandTables)
            {
                var productInnvoation = productInnvoations.FirstOrDefault(s => s.Stage == item.Stage);
                if (productInnvoation == null)
                {

                    productInnvoation = new ProductInnvoationTable()
                    {
                        Stage = item.Stage,
                        ID = agentStages.stages.IndexOf(item.Stage)
                    };
                    productInnvoations.Add(productInnvoation);
                }
                var indexStage = agentStages.stages.Count;// (item.Stage);
                Brand brand = (Brand)Enum.Parse(typeof(Brand), item.Brand);
                for (int i = productInnvoation.T.AIRC.Count; i < indexStage-1; i++)
                {
                    productInnvoation.T.AIRC.Add(new RC());
                    productInnvoation.AC.FIRC.Add(new RC());
                    productInnvoation.AL.MIRC.Add(new RC());
                }
                for (int i = 0; i < indexStage-1; i++)
                {
                    var surfaceRC= item.SurfaceRC.Count > i ? item.SurfaceRC[i] : 0;
                    var functionRC = item.FunctionRC.Count > i ? item.FunctionRC[i] : 0;
                    var materialRC = item.MaterialRC.Count > i ? item.MaterialRC[i] : 0;
                    switch (brand)
                    {
                        case Brand.M品牌:
                            productInnvoation.T.AIRC[i].M = surfaceRC;
                            productInnvoation.AC.FIRC[i].M = functionRC;
                            productInnvoation.AL.MIRC[i].M = materialRC;
                            break;
                        case Brand.S品牌:
                            productInnvoation.T.AIRC[i].S = surfaceRC;
                            productInnvoation.AC.FIRC[i].S = functionRC;
                            productInnvoation.AL.MIRC[i].S = materialRC;
                            break;
                        case Brand.J品牌:
                            productInnvoation.T.AIRC[i].J = surfaceRC;
                            productInnvoation.AC.FIRC[i].J = functionRC;
                            productInnvoation.AL.MIRC[i].J = materialRC;
                            break;
                    }
                }
            }
            SetInvovation(productInnvoations, productInnvoations.OrderByDescending(s => s.ID).Take(1).ToList()[0]);

        }
        private void SetInvovation(List<ProductInnvoationTable> products, ProductInnvoationTable product)
        {
            int index = agentStages.stages.IndexOf(product.Stage);
            if (index == 0) return;
            var last = products.FirstOrDefault(j => j.Stage == agentStages.stages[index - 1]);
            SetInvovation(products, last);

            for (int i = 0; i < last.InnovationIndexM.Count; i++)
            {
                if (product.K.IIXRC.Count <= i) product.K.IIXRC.Add(new RC());
                product.K.IIXRC[i].M = last.InnovationIndexM[i];
                product.K.IIXRC[i].S = last.InnovationIndexS[i];
                product.K.IIXRC[i].J = last.InnovationIndexJ[i];

            }


            if (index > 1)
            {
                //product.K.IIXRC.Add(new RC());
                product.K.IIXRC[index - 1] = initRC;
            }
            //if (index == 3)
            //{
            //    product.K.IIXRC[1].M = last.InnovationIndexM[1];
            //    product.K.IIXRC[1].S = last.InnovationIndexS[1];
            //    product.K.IIXRC[1].J = last.InnovationIndexJ[1];
            //    product.K.IIXRC[2] = initRC;
            //}
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
            for (int i = 0; i < K.IIXRC.Count; i++)
            {
                B.IIRC.Add(new RC
                {
                    M = K.IIXRC[i].Percent(1),
                    S = K.IIXRC[i].Percent(2),
                    J = K.IIXRC[i].Percent(3),

                });
            }

            #endregion

            #region 创新投入合计
            for (int i = 0; i < T.AIRC.Count; i++)
            {
                AU.ISRC.Add(new RC
                {
                    M = T.AIRC[i].M + AC.FIRC[i].M + AL.MIRC[i].M,
                    J = T.AIRC[i].J + AC.FIRC[i].J + AL.MIRC[i].J,
                    S = T.AIRC[i].S + AC.FIRC[i].S + AL.MIRC[i].S
                });
            }

            #endregion

            #region 外观创新指数
            for (int i = 0; i < T.AIRC.Count; i++)
            {
                BD.AIIRC.Add(new RC
                {
                    M = T.AIRC[i].Percent(1),
                    S = T.AIRC[i].Percent(2),
                    J = T.AIRC[i].Percent(3),

                });
            }
            #endregion

            #region 功能创新指数
            for (int i = 0; i < AC.FIRC.Count; i++)
            {
                BP.FIIRC.Add(new RC
                {
                    M = AC.FIRC[i].Percent(1),
                    S = AC.FIRC[i].Percent(2),
                    J = AC.FIRC[i].Percent(3),

                });
            }

            #endregion

            #region 产出系数
            for (int i = 0; i < T.AIRC.Count; i++)
            {
                CB.AORC.Add(new RC
                {
                    M = T.AIRC[i].OutputCoefficient(1),
                    S = T.AIRC[i].OutputCoefficient(2),
                    J = T.AIRC[i].OutputCoefficient(3),

                });
            }
            #endregion



        }
        public List<decimal> InnovationIndexM
        {
            get
            {
                var result = new List<decimal>();
                for (int i = 0; i < K.IIXRC.Count; i++)
                {
                    var res = Cal.InnovationIndex(K.IIXRC[i].M, BD.AIIRC[i].M, BD.AIIRC[i].Average, CB.AORC[i].M, BP.FIIRC[i].M, BP.FIIRC[i].Average, CK.FORC[i].M);

                    result.Add(res);
                }
                return result;
            }
        }
        public List<decimal> InnovationIndexS
        {
            get
            {
                var result = new List<decimal>();
                for (int i = 0; i < K.IIXRC.Count; i++)
                {
                    var res = Cal.InnovationIndex(K.IIXRC[i].S, BD.AIIRC[i].S, BD.AIIRC[i].Average, CB.AORC[i].S, BP.FIIRC[i].S, BP.FIIRC[i].Average, CK.FORC[i].S);
                    result.Add(res);
                }
                return result;
            }
        }
        public List<decimal> InnovationIndexJ
        {
            get
            {
                var result = new List<decimal>();
                for (int i = 0; i < K.IIXRC.Count; i++)
                {
                    var res = Cal.InnovationIndex(K.IIXRC[i].J, BD.AIIRC[i].J, BD.AIIRC[i].Average, CB.AORC[i].J, BP.FIIRC[i].J, BP.FIIRC[i].Average, CK.FORC[i].J);
                    result.Add(res);
                }
                return result;
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
                for (int i = 0; i < AC.FIRC.Count; i++)
                {
                    if (i == 0) result.FORC.Add(GetCK(AC.FIRC[i]));
                    else
                        result.FORC.Add(GetCK(AC.FIRC[i - 1], AC.FIRC[i]));
                }
                //result.FORC[0] = GetCK(AC.FIRC[0]);
                //result.FORC[1] = GetCK(AC.FIRC[0], AC.FIRC[1]);
                //result.FORC[2] = GetCK(AC.FIRC[1], AC.FIRC[2]);
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
                M = Cal.FunctionIndex(m, s, j, Averaget),
                S = Cal.FunctionIndex(s, j, m, Averaget),
                J = Cal.FunctionIndex(j, m, s, Averaget),
            };
        }

        private RC GetCK(RC rc1, RC rc2)
        {
            //=IF(AND(AF5>AD5,AF5>AE5),1.3,IF(AND(AF5<AD5,AF5<AE5),(0.7),IF(AF5>AVERAGE(AD5:AF5),1.15,IF(AF5=AVERAGE(AD5:AF5),1,0.85))))
            //  = IF(AND(AG5 > AE5, AG5 > AF5), 1.3, IF(AND(AG5 < AE5, AG5 < AF5), (0.7), IF(AG5 > AVERAGE(AE5: AG5), 1.15, IF(AG5 = AVERAGE(AE5: AG5), 1, 0.85))))

            RC rct1 = new RC { M = rc2.M, S = rc1.S, J = rc1.J };
            RC rct2 = new RC { M = rc2.S, S = rc1.J, J = rc2.M };
            RC rct3 = new RC { M = rc2.J, S = rc2.M, J = rc2.S };

            return new RC
            {
                M = Cal.FunctionIndex(rct1.M, rct1.S, rct1.J, rct1.Average),
                S = Cal.FunctionIndex(rct2.M, rct2.S, rct2.J, rct2.Average),
                J = Cal.FunctionIndex(rct3.M, rct3.S, rct3.J, rct3.Average),
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
                for (int i = 0; i < AL.MIRC.Count; i++)
                {
                    result.PFRC.Add(new RC
                    {
                        M = AL.MIRC[i].M / 100 * 0.02M,
                        S = AL.MIRC[i].S / 100 * 0.02M,
                        J = AL.MIRC[i].J / 100 * 0.02M,

                    });
                }

                return result;
            }
        }
        public List<decimal> DDStage
        {
            get
            {
                var result = new List<decimal>();
                for (int i = 0; i < B.IIRC.Count; i++)
                {
                    result.Add(B.IIRC[i].Sum);
                }

                return result;
            }
        }

    }
    public class InnovationImpact
    {
        public List<RC> IIRC { get; set; } = new List<RC>();

    }
    public class InnovationIndex
    {
        public List<RC> IIXRC { get; set; } = new List<RC>();

    }
    public class AppearanceInvestment
    {
        public List<RC> AIRC { get; set; } = new List<RC>();

    }
    public class FunctionInvestment
    {
        public List<RC> FIRC { get; set; } = new List<RC>();

    }
    public class MaterialInvestment
    {
        public List<RC> MIRC { get; set; } = new List<RC>();

    }
    public class InvestmentSum
    {
        public List<RC> ISRC { get; set; } = new List<RC>();

    }

    public class AppearanceInnovationIndex
    {
        public List<RC> AIIRC { get; set; } = new List<RC>();

    }
    public class AppearanceOutput
    {
        public List<RC> AORC { get; set; } = new List<RC>();

    }
    public class FunctionInnovationIndex
    {
        public List<RC> FIIRC { get; set; } = new List<RC>();

    }
    public class FunctionOutput
    {
        public List<RC> FORC { get; set; } = new List<RC>();

    }
    public class ProfitFactor
    {
        public List<RC> PFRC { get; set; } = new List<RC>();

    }

}