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
        List<InvestmentTable> investments;

        public ChannelService()
        {
            investments = new Investment().Get();
            Init();
        }
        private void Init()
        {
            ChannelServiceTable channl0 = new ChannelServiceTable()
            {
                Stage = Stage.起始阶段.ToString(),
            };
            Type t = channl0.J.GetType();
            PropertyInfo[] propertyList = t.GetProperties();
            foreach (var item in propertyList)
            {
                if(item.CanWrite)
                item.SetValue(channl0.J, 0.98m, null);
            }
            channelServices.Add(channl0);
            foreach (var item in investments)
            {
                var channel = channelServices.FirstOrDefault(s => s.Stage == item.Stage);
                if (channel == null)
                {
                    channel = new ChannelServiceTable { Stage = item.Stage };
                }
                channel.B.M = item.V.servet;
                channel.B.J = item.AC.servet;
                channel.B.Agent1 = item.CL.servet;
                channel.B.Agent2 = item.CT.servet;
                channel.B.Agent3 = item.DB.servet;
                channel.B.Agent4 = item.DJ.servet;
                channel.B.Agent5 = item.DR.servet;
                channel.B.Agent6 = item.DZ.servet;
                channelServices.Add(channel);
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
        public MJA J { get; set; } = new MJA();
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