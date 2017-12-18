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
            stageadds.Add(new Models.StageAdd { Stage =  "起始阶段" });
            stageadds.Add(new Models.StageAdd { Stage = "第一阶段"});
            stageadds.Add(new Models.StageAdd { Stage = "第二阶段" });
            stageadds.Add(new Models.StageAdd { Stage = "第三阶段" });
            stageadds.Add(new Models.StageAdd { AgentName= "代1"  });
            stageadds.Add(new Models.StageAdd { AgentName= "代2"  });
            stageadds.Add(new Models.StageAdd { AgentName= "代3"  });
            stageadds.Add(new Models.StageAdd { AgentName= "代4"  });
            stageadds.Add(new Models.StageAdd { AgentName= "代5"  });
            stageadds.Add(new Models.StageAdd { AgentName = "代6" });
       
            agents = stageadds.Where(s=>s.AgentName!=null).Select(s => s.AgentName).Distinct().ToList();
          stages = stageadds.Where(s=>s.Stage!=null).Select(s => s.Stage).Distinct().ToList();
           }

    }
}