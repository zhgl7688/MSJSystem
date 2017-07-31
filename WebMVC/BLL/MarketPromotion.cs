using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.BLL
{
    /// <summary>
    ///市场推广（包含促销投入） 
    /// </summary>
    public class MarketPromotion
    {
        List<MarketPromotionTable> marketPromotions = new List<MarketPromotionTable>();
        List<InvestmentTable> inverstments;
        public MarketPromotion()
        {
            inverstments = new Investment().Get();
            init();
        }
        public void init()
        {

            foreach (var item in inverstments)
            {
                var t1 = new MarketPromotionTable()
                {
                    Stage = item.Stage,
                };

                #region 终端形象投入							
                t1.B.M = item.V.EndImage;
                t1.B.J = item.AC.EndImage;
                t1.B.Agent1 = item.CL.EndImage;
                t1.B.Agent2 = item.CT.EndImage;
                t1.B.Agent3 = item.DB.EndImage;
                t1.B.Agent4 = item.DJ.EndImage;
                t1.B.Agent5 = item.DR.EndImage;
                t1.B.Agent6 = item.DZ.EndImage;
                #endregion

                #region 导购派驻投入							
                t1.J.M = item.V.Salesperson;
                t1.J.J = item.AC.Salesperson;
                t1.J.Agent1 = item.CL.Salesperson;
                t1.J.Agent2 = item.CT.Salesperson;
                t1.J.Agent3 = item.DB.Salesperson;
                t1.J.Agent4 = item.DJ.Salesperson;
                t1.J.Agent5 = item.DR.Salesperson;
                t1.J.Agent6 = item.DZ.Salesperson;
                #endregion

                #region 店内促销投入							
                t1.R.M = item.V.HousePromote;
                t1.R.J = item.AC.HousePromote;
                t1.R.Agent1 = item.CL.HousePromote;
                t1.R.Agent2 = item.CT.HousePromote;
                t1.R.Agent3 = item.DB.HousePromote;
                t1.R.Agent4 = item.DJ.HousePromote;
                t1.R.Agent5 = item.DR.HousePromote;
                t1.R.Agent6 = item.DZ.HousePromote;
                #endregion

                #region 演示开展投入							
                t1.Z.M = item.V.demonstrator;
                t1.Z.J = item.AC.demonstrator;
                t1.Z.Agent1 = item.CL.demonstrator;
                t1.Z.Agent2 = item.CT.demonstrator;
                t1.Z.Agent3 = item.DB.demonstrator;
                t1.Z.Agent4 = item.DJ.demonstrator;
                t1.Z.Agent5 = item.DR.demonstrator;
                t1.Z.Agent6 = item.DZ.demonstrator;
                #endregion

                #region 户外活动投入							
                t1.AH.M = item.V.outdoorActivity;
                t1.AH.J = item.AC.outdoorActivity;
                t1.AH.Agent1 = item.CL.outdoorActivity;
                t1.AH.Agent2 = item.CT.outdoorActivity;
                t1.AH.Agent3 = item.DB.outdoorActivity;
                t1.AH.Agent4 = item.DJ.outdoorActivity;
                t1.AH.Agent5 = item.DR.outdoorActivity;
                t1.AH.Agent6 = item.DZ.outdoorActivity;
                #endregion

                #region 推广小分队投入							
                t1.AP.M = item.V.promotionTeam;
                t1.AP.J = item.AC.promotionTeam;
                t1.AP.Agent1 = item.CL.promotionTeam;
                t1.AP.Agent2 = item.CT.promotionTeam;
                t1.AP.Agent3 = item.DB.promotionTeam;
                t1.AP.Agent4 = item.DJ.promotionTeam;
                t1.AP.Agent5 = item.DR.promotionTeam;
                t1.AP.Agent6 = item.DZ.promotionTeam;
                #endregion
                t1.MPCal();
                marketPromotions.Add(t1);
            }

        }
        public List<MarketPromotionTable> Get()
        {
            return marketPromotions;
        }
    }
    public class MarketPromotionTable
    {
        public string Stage { get; set; }
        public MP B { get; set; } = new MP();
        public MP J { get; set; } = new MP();
        public MP R { get; set; } = new MP();
        public MP Z { get; set; } = new MP();
        public MP AH { get; set; } = new MP();
        public MP AP { get; set; } = new MP();
        public MJA AX { get; set; } = new MJA();
        public MJA BP { get; set; } = new MJA();
        public void MPCal()
        {
            #region 市场推广指数
            AX.M1 = Cal.MarketingIndex(B.M, B.J, B.Agent1, J.M, J.J, J.Agent1, R.M, R.J, R.Agent1, Z.M, Z.J, Z.Agent1, AH.M, AH.J, AH.Agent1, AP.M, AP.J, AP.Agent1);
            AX.M2 = Cal.MarketingIndex(B.M, B.J, B.Agent2, J.M, J.J, J.Agent2, R.M, R.J, R.Agent2, Z.M, Z.J, Z.Agent2, AH.M, AH.J, AH.Agent2, AP.M, AP.J, AP.Agent2);
            AX.M3 = Cal.MarketingIndex(B.M, B.J, B.Agent3, J.M, J.J, J.Agent3, R.M, R.J, R.Agent3, Z.M, Z.J, Z.Agent3, AH.M, AH.J, AH.Agent3, AP.M, AP.J, AP.Agent3);
            AX.M4 = Cal.MarketingIndex(B.M, B.J, B.Agent4, J.M, J.J, J.Agent4, R.M, R.J, R.Agent4, Z.M, Z.J, Z.Agent4, AH.M, AH.J, AH.Agent4, AP.M, AP.J, AP.Agent4);
            AX.M5 = Cal.MarketingIndex(B.M, B.J, B.Agent5, J.M, J.J, J.Agent5, R.M, R.J, R.Agent5, Z.M, Z.J, Z.Agent5, AH.M, AH.J, AH.Agent5, AP.M, AP.J, AP.Agent5);
            AX.M6 = Cal.MarketingIndex(B.M, B.J, B.Agent6, J.M, J.J, J.Agent6, R.M, R.J, R.Agent6, Z.M, Z.J, Z.Agent6, AH.M, AH.J, AH.Agent6, AP.M, AP.J, AP.Agent6);
            AX.J1 = Cal.MarketingIndex(B.J, B.M, B.Agent1, J.J, J.M, J.Agent1, R.J, R.M, R.Agent1, Z.J, Z.M, Z.Agent1, AH.J, AH.M, AH.Agent1, AP.J, AP.M, AP.Agent1);
            AX.J2 = Cal.MarketingIndex(B.J, B.M, B.Agent2, J.J, J.M, J.Agent2, R.J, R.M, R.Agent2, Z.J, Z.M, Z.Agent2, AH.J, AH.M, AH.Agent2, AP.J, AP.M, AP.Agent2);
            AX.J3 = Cal.MarketingIndex(B.J, B.M, B.Agent3, J.J, J.M, J.Agent3, R.J, R.M, R.Agent3, Z.J, Z.M, Z.Agent3, AH.J, AH.M, AH.Agent3, AP.J, AP.M, AP.Agent3);
            AX.J4 = Cal.MarketingIndex(B.J, B.M, B.Agent4, J.J, J.M, J.Agent4, R.J, R.M, R.Agent4, Z.J, Z.M, Z.Agent4, AH.J, AH.M, AH.Agent4, AP.J, AP.M, AP.Agent4);
            AX.J5 = Cal.MarketingIndex(B.J, B.M, B.Agent5, J.J, J.M, J.Agent5, R.J, R.M, R.Agent5, Z.J, Z.M, Z.Agent5, AH.J, AH.M, AH.Agent5, AP.J, AP.M, AP.Agent5);
            AX.J6 = Cal.MarketingIndex(B.J, B.M, B.Agent6, J.J, J.M, J.Agent6, R.J, R.M, R.Agent6, Z.J, Z.M, Z.Agent6, AH.J, AH.M, AH.Agent6, AP.J, AP.M, AP.Agent6);
            AX.Agent1 = Cal.MarketingIndex(B.Agent1, B.J, B.M, J.Agent1, J.J, J.M, R.Agent1, R.J, R.M, Z.Agent1, Z.J, Z.M, AH.Agent1, AH.J, AH.M, AP.Agent1, AP.J, AP.M);
            AX.Agent2 = Cal.MarketingIndex(B.Agent2, B.J, B.M, J.Agent2, J.J, J.M, R.Agent2, R.J, R.M, Z.Agent2, Z.J, Z.M, AH.Agent2, AH.J, AH.M, AP.Agent2, AP.J, AP.M);
            AX.Agent3 = Cal.MarketingIndex(B.Agent3, B.J, B.M, J.Agent3, J.J, J.M, R.Agent3, R.J, R.M, Z.Agent3, Z.J, Z.M, AH.Agent3, AH.J, AH.M, AP.Agent3, AP.J, AP.M);
            AX.Agent4 = Cal.MarketingIndex(B.Agent4, B.J, B.M, J.Agent4, J.J, J.M, R.Agent4, R.J, R.M, Z.Agent4, Z.J, Z.M, AH.Agent4, AH.J, AH.M, AP.Agent4, AP.J, AP.M);
            AX.Agent5 = Cal.MarketingIndex(B.Agent5, B.J, B.M, J.Agent5, J.J, J.M, R.Agent5, R.J, R.M, Z.Agent5, Z.J, Z.M, AH.Agent5, AH.J, AH.M, AP.Agent5, AP.J, AP.M);
            AX.Agent6 = Cal.MarketingIndex(B.Agent6, B.J, B.M, J.Agent6, J.J, J.M, R.Agent6, R.J, R.M, Z.Agent6, Z.J, Z.M, AH.Agent6, AH.J, AH.M, AP.Agent6, AP.J, AP.M);
            #endregion
            #region 市场推广影响力

            BP.M1 = AX.M1 + AX.J1 + AX.Agent1 == 0 ? 0 : AX.M1 / (AX.M1 + AX.J1 + AX.Agent1);
            BP.M2 = AX.M2 + AX.J2 + AX.Agent2 == 0 ? 0 : AX.M2 / (AX.M2 + AX.J2 + AX.Agent2);
            BP.M3 = AX.M3 + AX.J3 + AX.Agent3 == 0 ? 0 : AX.M3 / (AX.M3 + AX.J3 + AX.Agent3);
            BP.M4 = AX.M4 + AX.J4 + AX.Agent4 == 0 ? 0 : AX.M4 / (AX.M4 + AX.J4 + AX.Agent4);
            BP.M5 = AX.M5 + AX.J5 + AX.Agent5 == 0 ? 0 : AX.M5 / (AX.M5 + AX.J5 + AX.Agent5);
            BP.M6 = AX.M6 + AX.J6 + AX.Agent6 == 0 ? 0 : AX.M6 / (AX.M6 + AX.J6 + AX.Agent6);
            BP.J1 = AX.M1 + AX.J1 + AX.Agent1 == 0 ? 0 : AX.J1 / (AX.M1 + AX.J1 + AX.Agent1);
            BP.J2 = AX.M2 + AX.J2 + AX.Agent2 == 0 ? 0 : AX.J2 / (AX.M2 + AX.J2 + AX.Agent2);
            BP.J3 = AX.M3 + AX.J3 + AX.Agent3 == 0 ? 0 : AX.J3 / (AX.M3 + AX.J3 + AX.Agent3);
            BP.J4 = AX.M4 + AX.J4 + AX.Agent4 == 0 ? 0 : AX.J4 / (AX.M4 + AX.J4 + AX.Agent4);
            BP.J5 = AX.M5 + AX.J5 + AX.Agent5 == 0 ? 0 : AX.J5 / (AX.M5 + AX.J5 + AX.Agent5);
            BP.J6 = AX.M6 + AX.J6 + AX.Agent6 == 0 ? 0 : AX.J6 / (AX.M6 + AX.J6 + AX.Agent6);
            BP.Agent1 = AX.M1 + AX.J1 + AX.Agent1 == 0 ? 0 : AX.Agent1 / (AX.M1 + AX.J1 + AX.Agent1);
            BP.Agent2 = AX.M2 + AX.J2 + AX.Agent2 == 0 ? 0 : AX.Agent2 / (AX.M2 + AX.J2 + AX.Agent2);
            BP.Agent3 = AX.M3 + AX.J3 + AX.Agent3 == 0 ? 0 : AX.Agent3 / (AX.M3 + AX.J3 + AX.Agent3);
            BP.Agent4 = AX.M4 + AX.J4 + AX.Agent4 == 0 ? 0 : AX.Agent4 / (AX.M4 + AX.J4 + AX.Agent4);
            BP.Agent5 = AX.M5 + AX.J5 + AX.Agent5 == 0 ? 0 : AX.Agent5 / (AX.M5 + AX.J5 + AX.Agent5);
            BP.Agent6 = AX.M6 + AX.J6 + AX.Agent6 == 0 ? 0 : AX.Agent6 / (AX.M6 + AX.J6 + AX.Agent6);
            #endregion

        }
        public decimal CI
        {
            get
            {
                return BP.M1 + BP.J1 + BP.Agent1;
            }
        }
        public decimal CJ
        {
            get
            {
                return BP.M2 + BP.J2 + BP.Agent2;
            }
        }
        public decimal CK
        {
            get
            {
                return BP.M3 + BP.J3 + BP.Agent3;
            }
        }
        public decimal CL
        {
            get
            {
                return BP.M4 + BP.J4 + BP.Agent4;
            }
        }
        public decimal CM
        {
            get
            {
                return BP.M5 + BP.J5 + BP.Agent5;
            }
        }
        public decimal CN
        {
            get
            {
                return BP.M6 + BP.J6 + BP.Agent6;
            }
        }
    }


}