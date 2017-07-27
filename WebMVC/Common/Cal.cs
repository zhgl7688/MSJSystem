using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Common
{
    public static class Cal
    {
        public static decimal EndImage(decimal AJ,decimal CS,decimal CL)
        {
            //=IF(2*AJ5>=CS5,CL5/2,IF(AJ5<CL5/2,AJ5,CL5/2))
            return 2 * AJ >= CS ? CL / 2 : AJ < CL / 2 ? AJ : CL / 2;
        }
        public static decimal Salesperson(decimal AJ, decimal CS, decimal CM,decimal AK)
        {
            //=IF(2*AJ5>=CS5,CM5/2,IF((AJ5-AK5)<CM5/2,(AJ5-AK5),CM5/2))
            return 2 * AJ >= CS ? CM / 2 : AJ-AK < CM / 2 ? AJ-AK : CM / 2;
        }
        public static decimal Servet(decimal AJ, decimal CS, decimal CR, decimal AK,decimal AL)
        {
            //=IF(2*AJ5>=CS5,CR5/2,IF((AJ5-AK5-AL5)<CR5/2,(AJ5-AK5-AL5),CR5/2))
            return 2 * AJ >= CS ? CR / 2 : AJ - AK -AL< CR / 2 ? AJ - AK-AL : CR / 2;
        }
        public static decimal HousePromote(decimal AJ, decimal CS, decimal CN, decimal AK,decimal AL,decimal AQ)
        {
            //=IF(2*AJ5>=CS5,CN5/2,IF((AJ5-AK5-AL5-AQ5)<CN5/2,(AJ5-AK5-AL5-AQ5),CN5/2))
            return 2 * AJ >= CS ? CN / 2 : AJ - AK-AL-AQ < CN / 2 ? AJ - AK -AL-AQ: CN / 2;
        }
        public static decimal Demonstrator(decimal AJ, decimal CS, decimal CO, decimal AK, decimal AL, decimal AQ,decimal AM)
        {
            //=IF(2*AJ5>=CS5,CO5/2,IF((AJ5-AK5-AL5-AM5-AQ5)<CO5/2,(AJ5-AK5-AL5-AM5-AQ5),CO5/2))
            return 2 * AJ >= CS ? CO / 2 : AJ - AK - AL - AQ-AM < CO / 2 ? AJ - AK - AL - AQ-AM : CO / 2;
        }
  
        public static decimal OutdoorActivity(decimal AJ, decimal CS, decimal CP, decimal AK, decimal AL, decimal AQ, decimal AM,decimal AN)
        {
            //=IF(2*AJ5>=CS5,CP5/2,IF((AJ5-AK5-AL5-AM5-AN5-AQ5)<CP5/2,(AJ5-AK5-AL5-AM5-AN5-AQ5),CP5/2))
            return 2 * AJ >= CS ? CP / 2 : AJ - AK - AL - AQ - AM -AN< CP / 2 ? AJ - AK - AL - AQ - AM-AN : CP / 2;
        }
        public static decimal PromotionTeam(decimal AJ, decimal CS, decimal CQ, decimal AK, decimal AL, decimal AQ, decimal AM, decimal AN,decimal AO)
        {
            // =IF(2*AJ5>=CS5, CQ5/2, IF((AJ5-AK5-AL5-AM5-AN5-AO5-AQ5)<CQ5/2,(AJ5-AK5-AL5-AM5-AN5-AO5-AQ5),CQ5/2))
            return 2 * AJ >= CS ? CQ / 2 : AJ - AK - AL - AQ - AM - AN-AO < CQ / 2 ? AJ - AK - AL - AQ - AM - AN-AO : CQ / 2;
        }
       
    }
}