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
        public ChannelService(InvertmentTable1 invertmentTable1)
        {
            brands = invertmentTable1.getBrandTable();
              agents = invertmentTable1.getAgents();
            Init();
        }
        private void Init()
        {
            #region 起始阶段
            ChannelServiceTable channl0 = new ChannelServiceTable()
            {
                Stage = Stage.起始阶段.ToString(),
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

                channel.B.Agent1 = itemAgent.B.servet;
                channel.B.Agent2 = itemAgent.J.servet;
                channel.B.Agent3 = itemAgent.R.servet;
                channel.B.Agent4 = itemAgent.Z.servet;
                channel.B.Agent5 = itemAgent.AH.servet;
                channel.B.Agent6 = itemAgent.AP.servet;
            }
            #endregion
            foreach (var item in channelServices)
            {
                if (item.Stage == Stage.第一阶段.ToString()) item.LastAB = channl0.AB;
                else
                if (item.Stage == Stage.第二阶段.ToString()) item.LastAB = channelServices.FirstOrDefault(s => s.Stage == Stage.第一阶段.ToString()).AB;
                else if (item.Stage == Stage.第三阶段.ToString()) item.LastAB = channelServices.FirstOrDefault(s => s.Stage == Stage.第二阶段.ToString()).AB;

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
                if (Stage == Common.Stage.起始阶段.ToString())
                {
                    var result = new MJA()
                    {
                        M1 =0.98m,
                        M2 =0.98m,
                        M3 =0.98m,
                        M4 =0.98m,
                        M5 =0.98m,
                        M6 =0.98m,
                        J1 =0.98m,
                        J2 =0.98m,
                        J3 =0.98m,
                        J4 =0.98m,
                        J5 =0.98m,
                        J6 =0.98m,
                        Agent1 =0.98m,
                        Agent2 =0.98m,
                        Agent3 =0.98m,
                        Agent4 =0.98m,
                        Agent5 =0.98m,
                        Agent6 =0.98m,
                    };
                    return result;
                }
                else
                {


                    var result = new MJA()
                    {
                        M1 = LastAB.M1 * 0.4m + Cal.Percent(B.M, B.J, B.Agent1),
                        M2 = LastAB.M2 * 0.4m + Cal.Percent(B.M, B.J, B.Agent2),
                        M3 = LastAB.M3 * 0.4m + Cal.Percent(B.M, B.J, B.Agent3),
                        M4 = LastAB.M4 * 0.4m + Cal.Percent(B.M, B.J, B.Agent4),
                        M5 = LastAB.M5 * 0.4m + Cal.Percent(B.M, B.J, B.Agent5),
                        M6 = LastAB.M6 * 0.4m + Cal.Percent(B.M, B.J, B.Agent6),
                        J1 = LastAB.J1 * 0.4m + Cal.Percent(B.J, B.M, B.Agent1),
                        J2 = LastAB.J2 * 0.4m + Cal.Percent(B.J, B.M, B.Agent2),
                        J3 = LastAB.J3 * 0.4m + Cal.Percent(B.J, B.M, B.Agent3),
                        J4 = LastAB.J4 * 0.4m + Cal.Percent(B.J, B.M, B.Agent4),
                        J5 = LastAB.J5 * 0.4m + Cal.Percent(B.J, B.M, B.Agent5),
                        J6 = LastAB.J6 * 0.4m + Cal.Percent(B.J, B.M, B.Agent6),
                        Agent1 = LastAB.Agent1 * 0.4m + Cal.Percent(B.Agent1, B.M, B.J),
                        Agent2 = LastAB.Agent2 * 0.4m + Cal.Percent(B.Agent2, B.M, B.J),
                        Agent3 = LastAB.Agent3 * 0.4m + Cal.Percent(B.Agent3, B.M, B.J),
                        Agent4 = LastAB.Agent4 * 0.4m + Cal.Percent(B.Agent4, B.M, B.J),
                        Agent5 = LastAB.Agent5 * 0.4m + Cal.Percent(B.Agent5, B.M, B.J),
                        Agent6 = LastAB.Agent6 * 0.4m + Cal.Percent(B.Agent6, B.M, B.J),
                    };
                    return result;
                }
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
            return new MJA()
            {
                M1 = Cal.Percent(J.M1, J.J1, J.Agent1),
                M2 = Cal.Percent(J.M2, J.J2, J.Agent2),
                M3 = Cal.Percent(J.M3, J.J3, J.Agent3),
                M4 = Cal.Percent(J.M4, J.J4, J.Agent4),
                M5 = Cal.Percent(J.M5, J.J5, J.Agent5),
                M6 = Cal.Percent(J.M6, J.J6, J.Agent6),
                J1 = Cal.Percent(J.J1, J.M1, J.Agent1),
                J2 = Cal.Percent(J.J2, J.M2, J.Agent2),
                J3 = Cal.Percent(J.J3, J.M3, J.Agent3),
                J4 = Cal.Percent(J.J4, J.M4, J.Agent4),
                J5 = Cal.Percent(J.J5, J.M5, J.Agent5),
                J6 = Cal.Percent(J.J6, J.M6, J.Agent6),
                Agent1 = Cal.Percent(J.Agent1, J.M1, J.J1),
                Agent2 = Cal.Percent(J.Agent2, J.M2, J.J2),
                Agent3 = Cal.Percent(J.Agent3, J.M3, J.J3),
                Agent4 = Cal.Percent(J.Agent4, J.M4, J.J4),
                Agent5 = Cal.Percent(J.Agent5, J.M5, J.J5),
                Agent6 = Cal.Percent(J.Agent6, J.M6, J.J6),
            };
        }
        public decimal AU
        {
            get
            {
                return AB.M1 + AB.J1 + AB.Agent1;
            }
        }
        public decimal AV
        {
            get
            {
                return AB.M2 + AB.J2 + AB.Agent2;
            }
        }
        public decimal AW
        {
            get
            {
                return AB.M3 + AB.J3 + AB.Agent3;
            }
        }
        public decimal AX
        {
            get
            {
                return AB.M4 + AB.J4 + AB.Agent4;
            }
        }
        public decimal AY
        {
            get
            {
                return AB.M5 + AB.J5 + AB.Agent5;
            }
        }
        public decimal AZ
        {
            get
            {
                return AB.M6 + AB.J6 + AB.Agent6;
            }
        }
    }
}