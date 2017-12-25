using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.BLL
{
    public class AgentStages
    {
        public List<string> agents { get; set; }
        public List<string> stages { get; set; }
        public AgentStages()
        {
            //代理数
            //using (var db = new Infrastructure.AppIdentityDbContext())
            //{
            //    agents = db.StageAdd.Select(s => s.AgentName).Distinct().ToList();
            //    aCount = agents.Count();
            //    stages = db.StageAdd.Select(s => s.Stage).Distinct().ToList();
            //    bCount = stages.Count();
            //}

            var stageadds = new List<Models.StageAdd>();
            stageadds.Add(new Models.StageAdd { Stage = "起始阶段" });
            stageadds.Add(new Models.StageAdd { Stage = "第1阶段" });
            stageadds.Add(new Models.StageAdd { Stage = "第2阶段" });
            stageadds.Add(new Models.StageAdd { Stage = "第3阶段" });

            agents = new List<string> {

 "代1" ,
 "代2" ,
 "代3" ,
 "代4" ,
 "代5" ,
 "代6" ,
       };

            stages = stageadds.Where(s => s.Stage != null).Select(s => s.Stage).Distinct().ToList();
        }

    }
}