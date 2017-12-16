using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.BLL
{
    public class AgentStages
    {
        public int aCount { get; set; }
        public int bCount { get; set; }
        public List<string> agents { get; set; }
        public List<string> stages { get; set; }   
        public AgentStages()
        {
            //代理数
            using (var db = new Infrastructure.AppIdentityDbContext())
            {
                agents = db.StageAdd.Select(s => s.AgentName).Distinct().ToList();
                aCount = agents.Count();
                stages = db.StageAdd.Select(s => s.Stage).Distinct().ToList();
                bCount = stages.Count();
            }
        }

    }
}