using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public static class AgentStages
    {
        internal static List<CurrentShareInit> CurrentShareInits;

        public static List<string> agents { get; set; }
        public static List<string> stages { get; set; }
        public static int BrandStrength_E { get;  set; }
        public static int BrandStrength_M1 { get;  set; }
        public static ProductInnovationInit ProductInnovationInit { get; internal set; }
        public static decimal M_AY1 { get; internal set; }
        public static decimal M_AY2 { get; internal set; }
        public static decimal M_AX1 { get; internal set; }
        public static decimal M_AX2 { get; internal set; }
        public static decimal M_AX3 { get; internal set; }
        public static decimal M_AX4 { get; internal set; }

        public static decimal M_AX5 { get; internal set; }
        public static decimal M_AX6 { get; internal set; }
        public static decimal C_J1 { get; internal set; }
        public static decimal C_J2 { get; internal set; }
        public static decimal MP_CD { get; internal set; }
        public static decimal MP_CE { get; internal set; }
        public static decimal MP_CF { get; internal set; }
        public static decimal MP_CM { get; internal set; }
        public static decimal MP_CN { get; internal set; }
        public static decimal MP_CO { get; internal set; }


        // var stageadds = new List<Models.StageAdd>();
        // stageadds.Add(new Models.StageAdd { Stage = "起始阶段" });
        //stageadds.Add(new Models.StageAdd { Stage = "第1阶段" });
        //stageadds.Add(new Models.StageAdd { Stage = "第2阶段" });
        //stageadds.Add(new Models.StageAdd { Stage = "第3阶段" });

        //           agents = new List<string> {

        //"代1" ,
        //"代2" ,
        //"代3" ,
        //"代4" ,
        //"代5" ,
        //"代6" ,
        //      };

        //  stages = stageadds.Where(s => s.Stage != null).Select(s => s.Stage).Distinct().ToList();


    }
}