using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Common;
using WebMVC.Models;
using System.Reflection;

namespace WebMVC.BLL
{
    /// <summary>
    /// 渠道服务
    /// </summary>
    public class ChannelService
    {

        List<ChannelServiceTable> channelServices = new List<ChannelServiceTable>();
        List<BrandTable> brands;
        List<AgentTable> agents;
        AgentStages agentStage;
        public ChannelService(InvertmentTable1 invertmentTable1)
        {

            brands = invertmentTable1.getBrandTable();
            agents = invertmentTable1.getAgents();
            agentStage = new AgentStages();
            Init();
        }
        private void Init()
        {
            #region 起始阶段
            ChannelServiceTable channl0 = new ChannelServiceTable()
            {
                Stage = agentStage.stages[0],
            };

            channelServices.Add(channl0);

            foreach (var item in brands)
            {
                var channel = channelServices.FirstOrDefault(s => s.Stage == item.Stage);
                if (channel == null)
                {
                    channel = new ChannelServiceTable { Stage = item.Stage };
                    channelServices.Add(channel);
                }
                if (item.Brand == Brand.M品牌.ToString()) { channel.B.M = item.servet; }
                else if (item.Brand == Brand.J品牌.ToString()) { channel.B.J = item.servet; }
            }
            foreach (var itemAgent in agents)
            {
                var channel = channelServices.FirstOrDefault(s => s.Stage == itemAgent.Stage);
                if (channel == null)
                {
                    channel = new ChannelServiceTable { Stage = itemAgent.Stage };
                    channelServices.Add(channel);

                }
                for (int i = 0; i < itemAgent.Bagent.Count; i++)
                {
                    channel.B.Agent.Add(itemAgent.Bagent[i].servet);
                }

                //channel.B.Agent1 = itemAgent.B.servet;
                //channel.B.Agent2 = itemAgent.J.servet;
                //channel.B.Agent3 = itemAgent.R.servet;
                //channel.B.Agent4 = itemAgent.Z.servet;
                //channel.B.Agent5 = itemAgent.AH.servet;
                //channel.B.Agent6 = itemAgent.AP.servet;
            }
            #endregion
            for (int i = 1; i < channelServices.Count; i++)
            {
                channelServices[i].LastAB = channelServices[i - 1].AB;
            }


        }
        public List<ChannelServiceTable> Get()
        {
            return channelServices;
        }
    }
    public class ChannelServiceTable
    {
        public string Stage { get; set; }
        /// <summary>
        /// 渠道服务投入							
        /// </summary>
        public MP B { get; set; } = new MP();
        /// <summary>
        /// 顾客满意度指数																	
        /// </summary>
        public MJA J
        {
            get
            {
                decimal I1 = 0;
                decimal I2 = 0;
                using (var db = new Infrastructure.AppIdentityDbContext())
                {

                    var bs = db.ChannelServiceInit.FirstOrDefault(s => s.id == 1);
                    if (bs != null)
                    {
                        I1 = bs.ChannelService_J1;
                        I2 = bs.ChannelService_J2;
                    }

                }

                var result = new MJA();
                var count = new AgentStages().agents.Count;
                for (int i = 0; i <count; i++)
                {

                    if (Stage == new AgentStages().stages[0])
                    {
                        result.M.Add(I2);
                        result.J.Add(I2);
                        result.Agent.Add(I2);
                    }
                    else
                    {
                        result.M.Add(LastAB.M[i] * I1 + Cal.Percent(B.M, B.J, B.Agent[i]));
                        result.J.Add(LastAB.J[i] * I1 + Cal.Percent(B.J, B.M, B.Agent[i]));
                        result.Agent.Add(LastAB.Agent[i] * I1 + Cal.Percent(B.Agent[i], B.M, B.J));
                    }
                }
                return result;
            }
        }
        /// <summary>
        /// 顾客满意度影响力																	
        /// </summary>
        public MJA AB
        {
            get
            {
                return ABCal();

            }
        }

        public MJA LastAB { get; set; } = new MJA();
        public MJA ABCal()
        {
            var mja = new MJA();
            for (int i = 0; i < J.M.Count; i++)
            {
                mja.M.Add(Cal.Percent(J.M[i], J.J[i], J.Agent[i]));
                mja.J.Add(Cal.Percent(J.J[i], J.M[i], J.Agent[i]));
                mja.Agent.Add(Cal.Percent(J.Agent[i], J.M[i], J.J[i]));
            }
            return mja;
        }
        public List<decimal> AUSum
        {
            get
            {
                var mjaSum = new List<decimal>();
                for (int i = 0; i < AB.M.Count; i++)
                {
                    mjaSum.Add(AB.M[i] + AB.J[i] + AB.Agent[i]);
                }
                return mjaSum;
            }

        }
       
         
    }
}